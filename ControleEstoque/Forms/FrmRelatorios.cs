using ControleEstoqueLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace ControleEstoque
{
    public partial class FrmRelatorios : Form
    {
        private List<PedidoModelo> pedidosList = new List<PedidoModelo>();
        private List<DepositoModelo> depositoList = new List<DepositoModelo>();
        private List<CargaDevoluçãoModelo> cargaDevoluçãoList = new List<CargaDevoluçãoModelo>();

        public FrmRelatorios()
        {
            InitializeComponent();
        }

        private void btSearchVendedor_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProcura(this.Name, "Vendedor", FrmVendedores.VendedorParameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    VendedorModelo ResultadoPesquisaVendedor = form.TableObjectVendedor[form.ResultID];

                    txtIdVendedor.Text = ResultadoPesquisaVendedor.Id.ToString();
                    txtNomeVendedor.Text = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Nome from Pessoa where Pessoa.ID == " + ResultadoPesquisaVendedor.PessoaId.ToString())[0].Nome;

                    List<VendedorPraçaModelo> vendedorPraça = SqliteAcessoDados.LoadQuery<VendedorPraçaModelo>("select * from VendedorPraça where VendedorPraça.VendedorID == " + ResultadoPesquisaVendedor.Id.ToString());

                    cbbPraça.Items.Clear();
                    foreach (VendedorPraçaModelo modelo in vendedorPraça)
                    {
                        PraçaModelo praça = SqliteAcessoDados.LoadQuery<PraçaModelo>("select * from Praça where Praça.ID == " + modelo.PraçaId.ToString()).First();
                        cbbPraça.Items.Add(praça.Id + " - " + praça.Nome);
                    }
                }
            }
        }

        #region TotalVendas

        private void btTotalVendas_Click(object sender, EventArgs e)
        {
            if (txtIdVendedor.Text != "")
            {
                if (txtDataFinal.Text != "" && txtDataInicial.Text != "")
                {
                    DateTime dataInicial = DateTime.Parse(txtDataInicial.Text);
                    DateTime dataFinal = DateTime.Parse(txtDataFinal.Text);

                    string query = "select * from Pedido where Pedido.VendedorID == " + txtIdVendedor.Text + " and date(Pedido.DataEmissão) BETWEEN date('" + dataInicial.Year + "-" + dataInicial.Month.ToString("00") + "-" + dataInicial.Day.ToString("00") + "') and date('" + dataFinal.Year + "-" + dataFinal.Month.ToString("00") + "-" + dataFinal.Day.ToString("00") + "') order by Pedido.DataEmissão";
                    pedidosList = SqliteAcessoDados.LoadQuery<PedidoModelo>(query);
                }
                else
                {
                    pedidosList = SqliteAcessoDados.LoadQuery<PedidoModelo>("select * from Pedido where Pedido.VendedorID == " + txtIdVendedor.Text + " order by Pedido.DataEmissão");
                }
            }
            else
            {
                pedidosList = SqliteAcessoDados.LoadQuery<PedidoModelo>("select * from Pedido order by Pedido.VendedorID");
            }

            if (pedidosList.Count > 0)
            {
                GerarRelatorioTotalVendas(pedidosList);
            }
        }

        private void GerarRelatorioTotalVendas(List<PedidoModelo> pedidos)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Relatorios";
            string fileName = "";
            bool unico = true;

            if (txtIdVendedor.Text != "")
            {
                VendedorModelo vendedor = SqliteAcessoDados.LoadQuery<VendedorModelo>("select * from Vendedor where Vendedor.ID == " + pedidos[0].VendedorID.ToString()).First();
                PessoaModelo vendedorPessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select * from Pessoa where Pessoa.ID == " + vendedor.PessoaId.ToString()).First();

                fileName = "Vendedor - " + vendedorPessoa.Nome + " - ";
                unico = true;
            }
            else
            {
                fileName = "Geral - ";
                unico = false;
            }

            if (txtDataFinal.Text != "" && txtDataInicial.Text != "")
            {
                if (txtDataFinal.Text == txtDataInicial.Text)
                {
                    fileName += DateTime.Parse(txtDataFinal.Text).Day.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Month.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Year.ToString();
                }
                else
                {
                    fileName += "De - " + DateTime.Parse(txtDataFinal.Text).Day.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Month.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Year.ToString() +
                        " - Até - " + DateTime.Parse(txtDataInicial.Text).Day.ToString() + "_" + DateTime.Parse(txtDataInicial.Text).Month.ToString() + "_" + DateTime.Parse(txtDataInicial.Text).Year.ToString();
                }
            }
            else
            {
                fileName += "Todas as Datas";
            }

            fileName += ".docx";

            System.IO.Directory.CreateDirectory(docPath);

            docPath = System.IO.Path.Combine(docPath, fileName);

            if (unico)
            {
                using (var document = DocX.Create(docPath))
                {
                    document.InsertParagraph("SABOR MINEIRO - RELATÓRIO").FontSize(11d).Bold().Alignment = Alignment.center;
                    document.InsertParagraph("TOTAL DE VENDAS").FontSize(10d).Bold().Alignment = Alignment.center;

                    CreateHeaderTotalVendas(pedidosList.First(), document);
                    Table t = document.AddTable(1, 7);
                    CreateTableTotalVendas(document, t);
                    t = CreateTableContentTotalVendas(pedidosList.First(), t);
                    t = CreateTableLastRowTotalVendas(t);

                    document.InsertTable(t);

                    try
                    {
                        document.Save();
                        DialogResult result = MessageBox.Show("Relatorio gerado na pasta Meus Documentos -> Relatorios(" + docPath + ")", "Atenção!", MessageBoxButtons.OK);
                    }
                    catch
                    {
                        DialogResult result = MessageBox.Show("Arquivo aberto em outro aplicativo, favor fecha-lo antes de continuar", "Atenção!", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                using (var document = DocX.Create(docPath))
                {
                    document.InsertParagraph("SABOR MINEIRO - RELATÓRIO").FontSize(11d).Bold().Alignment = Alignment.center;
                    document.InsertParagraph("TOTAL DE VENDAS").FontSize(10d).Bold().Alignment = Alignment.center;

                    int vendedorID = -1;

                    Table t = document.AddTable(1, 7);

                    for (int i = 0; i < pedidosList.Count; i++)
                    {
                        if (vendedorID != pedidosList[i].VendedorID)
                        {
                            CreateHeaderTotalVendas(pedidosList[i], document);

                            t = CreateTableTotalVendas(document, t);
                        }

                        t = CreateTableContentTotalVendas(pedidosList[i], t);

                        vendedorID = pedidosList[i].VendedorID;

                        if (i == pedidosList.Count - 1)
                        {
                            t = CreateTableLastRowTotalVendas(t);
                            document.InsertTable(t);
                        }
                        else if (vendedorID != pedidosList[i + 1].VendedorID)
                        {
                            t = CreateTableLastRowTotalVendas(t);
                            document.InsertTable(t);
                        }
                    }

                    try
                    {
                        document.Save();
                        DialogResult result = MessageBox.Show("Relatorio gerado na pasta Meus Documentos -> Relatorios(" + docPath + ")", "Atenção!", MessageBoxButtons.OK);
                    }
                    catch
                    {
                        DialogResult result = MessageBox.Show("Arquivo aberto em outro aplicativo, favor fecha-lo antes de continuar", "Atenção!", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void CreateHeaderTotalVendas(PedidoModelo pedido, DocX document)
        {
            VendedorModelo vendedor = SqliteAcessoDados.LoadQuery<VendedorModelo>("select * from Vendedor where Vendedor.ID == " + pedido.VendedorID.ToString()).First();
            PessoaModelo vendedorPessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select * from Pessoa where Pessoa.ID == " + vendedor.PessoaId).First();

            document.InsertParagraph();
            document.InsertParagraph("VENDEDOR: ")
                .Bold()
                .FontSize(10d)
                .Append(vendedorPessoa.Nome + "     ")
                .FontSize(10d)
                .Append("TELEFONE: ")
                .Bold()
                .FontSize(10d)
                .Append(vendedorPessoa.Telefone)
                .FontSize(10d)
                .Alignment = Alignment.left;

            document.InsertParagraph();
        }

        private Table CreateTableTotalVendas(DocX document, Table t)
        {
            t = document.AddTable(1, 7);
            t.Design = TableDesign.LightGridAccent3;
            t.Alignment = Alignment.center;
            t.AutoFit = AutoFit.Contents;

            t.Rows[0].Cells[0].Paragraphs.First().Append("PEDIDO").Bold().FontSize(10d).Alignment = Alignment.center;
            t.Rows[0].Cells[1].Paragraphs.First().Append("CÓDIGO").Bold().FontSize(10d).Alignment = Alignment.center;
            t.Rows[0].Cells[2].Paragraphs.First().Append("NOME CLIENTE").Bold().FontSize(10d).Alignment = Alignment.center;
            t.Rows[0].Cells[3].Paragraphs.First().Append("PRAÇA").Bold().FontSize(10d).Alignment = Alignment.center;
            t.Rows[0].Cells[4].Paragraphs.First().Append("DATA DE EMISSÃO").Bold().FontSize(10d).Alignment = Alignment.center;
            t.Rows[0].Cells[5].Paragraphs.First().Append("VALOR TOTAL").Bold().FontSize(10d).Alignment = Alignment.center;
            t.Rows[0].Cells[6].Paragraphs.First().Append("VALOR PAGO").Bold().FontSize(10d).Alignment = Alignment.center;

            return t;
        }

        private Table CreateTableContentTotalVendas(PedidoModelo pedido, Table t)
        {
            t.InsertRow();

            PessoaModelo clientePessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select * from Pessoa where Pessoa.ID == " + pedido.PessoaID).First();
            PraçaModelo praça = SqliteAcessoDados.LoadQuery<PraçaModelo>("select * from Praça where Praça.ID == " + pedido.PraçaID.ToString()).First();

            t.Rows.Last().Cells[0].Paragraphs.First().Append(pedido.Id.ToString()).FontSize(10d);
            t.Rows.Last().Cells[1].Paragraphs.First().Append(clientePessoa.Id.ToString()).FontSize(10d);
            t.Rows.Last().Cells[2].Paragraphs.First().Append(clientePessoa.Nome).FontSize(10d);
            t.Rows.Last().Cells[3].Paragraphs.First().Append(praça.Nome).FontSize(10d);
            t.Rows.Last().Cells[4].Paragraphs.First().Append(pedido.DataEmissão.ToShortDateString()).FontSize(10d);
            t.Rows.Last().Cells[5].Paragraphs.First().Append(string.Format("{0:C}", pedido.ValorTotal)).FontSize(10d);
            t.Rows.Last().Cells[6].Paragraphs.First().Append(string.Format("{0:C}", pedido.ValorPago)).FontSize(10d);

            return t;
        }

        private Table CreateTableLastRowTotalVendas(Table t)
        {
            decimal totalValorPago = 0;
            decimal totalValorTotal = 0;

            for (int i = 0; i < t.RowCount; i++)
            {
                if (i != 0)
                {
                    totalValorTotal += decimal.Parse(t.Rows[i].Cells[5].Paragraphs.First().Text.Replace("R$ ", ""));
                    totalValorPago += decimal.Parse(t.Rows[i].Cells[6].Paragraphs.First().Text.Replace("R$ ", ""));
                }
            }

            t.InsertRow();

            t.Rows.Last().Cells[4].Paragraphs.First().Append("TOTAL: ").Bold().FontSize(11d).Alignment = Alignment.right;
            t.Rows.Last().Cells[5].Paragraphs.First().Append(string.Format("{0:C}", totalValorTotal)).Bold().FontSize(11d);
            t.Rows.Last().Cells[6].Paragraphs.First().Append(string.Format("{0:C}", totalValorPago)).Bold().FontSize(11d);

            return t;
        }
        #endregion

        #region Estoque

        private void btEstoque_Click(object sender, EventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Relatorios";
            string fileName = "Estoque.docx";

            System.IO.Directory.CreateDirectory(docPath);

            docPath = System.IO.Path.Combine(docPath, fileName);

            using (var document = DocX.Create(docPath))
            {
                document.InsertParagraph("SABOR MINEIRO - RELATÓRIO").FontSize(11d).Bold().Alignment = Alignment.center;
                document.InsertParagraph("TOTAL DE VENDAS").FontSize(10d).Bold().Alignment = Alignment.center;
                document.InsertParagraph();

                Table t = document.AddTable(1, 3);

                t.Alignment = Alignment.center;
                t.Design = TableDesign.LightGridAccent3;

                t.Rows[0].Cells[0].Paragraphs.First().Append("CÓDIGO").Bold().FontSize(10d).Alignment = Alignment.center;
                t.Rows[0].Cells[1].Paragraphs.First().Append("PRODUTO").Bold().FontSize(10d).Alignment = Alignment.center;
                t.Rows[0].Cells[2].Paragraphs.First().Append("ESTOQUE").Bold().FontSize(10d).Alignment = Alignment.center;

                List<ProdutoModelo> produtos = SqliteAcessoDados.GetPesquisarTodos<ProdutoModelo>();

                foreach (ProdutoModelo produto in produtos)
                {
                    t.InsertRow();
                    t.Rows.Last().Cells[0].Paragraphs.First().Append(produto.Id.ToString()).FontSize(11d).Alignment = Alignment.center;
                    t.Rows.Last().Cells[1].Paragraphs.First().Append(produto.Descrição).FontSize(11d).Alignment = Alignment.center;
                    t.Rows.Last().Cells[2].Paragraphs.First().Append(produto.Estoque.ToString()).FontSize(11d).Alignment = Alignment.center;
                }

                document.InsertTable(t);

                try
                {
                    document.Save();
                    DialogResult result = MessageBox.Show("Relatorio gerado na pasta Meus Documentos -> Relatorios(" + docPath + ")", "Atenção!", MessageBoxButtons.OK);
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Arquivo aberto em outro aplicativo, favor fecha-lo antes de continuar", "Atenção!", MessageBoxButtons.OK);
                }
            }
        }

        #endregion

        #region Depositos

        private void btDepositos_Click(object sender, EventArgs e)
        {
            if (txtIdVendedor.Text != "")
            {
                if (cbbPraça.SelectedItem != null)
                {
                    if (txtDataFinal.Text != "" && txtDataInicial.Text != "")
                    {
                        DateTime dataInicial = DateTime.Parse(txtDataInicial.Text);
                        DateTime dataFinal = DateTime.Parse(txtDataFinal.Text);

                        string query = "select * from Deposito where Deposito.VendedorID == " + txtIdVendedor.Text + " and date(Deposito.Data) BETWEEN date('" + dataInicial.Year + "-" + dataInicial.Month.ToString("00") + "-" + dataInicial.Day.ToString("00") + "') and date('" + dataFinal.Year + "-" + dataFinal.Month.ToString("00") + "-" + dataFinal.Day.ToString("00") + "') order by Deposito.Data";
                        depositoList = SqliteAcessoDados.LoadQuery<DepositoModelo>(query);
                    }
                    else
                    {
                        depositoList = SqliteAcessoDados.LoadQuery<DepositoModelo>("select * from Deposito where Deposito.VendedorID == " + txtIdVendedor.Text + " order by Deposito.Data");
                    }

                    if (depositoList.Count > 0)
                    {
                        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Relatorios";

                        VendedorModelo vendedor = SqliteAcessoDados.LoadQuery<VendedorModelo>("select * from Vendedor where Vendedor.ID == " + txtIdVendedor.Text).First();
                        PessoaModelo vendedorPessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select * from Pessoa where Pessoa.ID == " + vendedor.PessoaId.ToString()).First();

                        string fileName = "Depositos - Vendedor - " + vendedorPessoa.Nome + " - Praça - " + cbbPraça.SelectedItem.ToString() + " - ";

                        if (txtDataFinal.Text != "" && txtDataInicial.Text != "")
                        {
                            if (txtDataFinal.Text == txtDataInicial.Text)
                            {
                                fileName += DateTime.Parse(txtDataFinal.Text).Day.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Month.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Year.ToString();
                            }
                            else
                            {
                                fileName += "De - " + DateTime.Parse(txtDataFinal.Text).Day.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Month.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Year.ToString() +
                                    " - Até - " + DateTime.Parse(txtDataInicial.Text).Day.ToString() + "_" + DateTime.Parse(txtDataInicial.Text).Month.ToString() + "_" + DateTime.Parse(txtDataInicial.Text).Year.ToString();
                            }
                        }
                        else
                        {
                            fileName += "Todas as Datas";
                        }

                        fileName += ".docx";

                        System.IO.Directory.CreateDirectory(docPath);

                        docPath = System.IO.Path.Combine(docPath, fileName);

                        using (var document = DocX.Create(docPath))
                        {
                            document.InsertParagraph("SABOR MINEIRO - RELATÓRIO").FontSize(11d).Bold().Alignment = Alignment.center;
                            document.InsertParagraph("TOTAL DE VENDAS").FontSize(10d).Bold().Alignment = Alignment.center;
                            document.InsertParagraph();

                            document.InsertParagraph("PROMOTOR: ").FontSize(10d).Bold()
                                .Append(txtNomeVendedor.Text).FontSize(10d)
                                .Alignment = Alignment.left;

                            document.InsertParagraph("PRAÇA: ").FontSize(10d).Bold()
                                .Append(cbbPraça.SelectedItem.ToString()).FontSize(10d)
                                .Alignment = Alignment.left;

                            document.InsertParagraph();

                            Table t = document.AddTable(1, 6);
                            t.AutoFit = AutoFit.Contents;
                            t.Design = TableDesign.LightGridAccent3;

                            t.Rows[0].Cells[0].Paragraphs.First().Append("DEPOSTIO").Bold().FontSize(10d).Alignment = Alignment.center;
                            t.Rows[0].Cells[1].Paragraphs.First().Append("DATA").Bold().FontSize(10d).Alignment = Alignment.center;
                            t.Rows[0].Cells[2].Paragraphs.First().Append("DIA SEMANA").Bold().FontSize(10d).Alignment = Alignment.center;
                            t.Rows[0].Cells[3].Paragraphs.First().Append("VALOR PAGO").Bold().FontSize(10d).Alignment = Alignment.center;
                            t.Rows[0].Cells[4].Paragraphs.First().Append("PEPINO").Bold().FontSize(10d).Alignment = Alignment.center;
                            t.Rows[0].Cells[5].Paragraphs.First().Append("TOTAL").Bold().FontSize(10d).Alignment = Alignment.center;

                            decimal totalPeriodo = 0;
                            decimal totalPepinoPeriodo = 0;
                            decimal totalGeralPeriodo = 0;

                            foreach (DepositoModelo deposito in depositoList)
                            {
                                t.InsertRow();
                                t.Rows.Last().Cells[0].Paragraphs.First().Append(deposito.Id.ToString()).FontSize(10d).Alignment = Alignment.left;
                                t.Rows.Last().Cells[1].Paragraphs.First().Append(deposito.Data.ToShortDateString()).FontSize(10d).Alignment = Alignment.left;
                                t.Rows.Last().Cells[2].Paragraphs.First().Append(DateTimeFormatInfo.CurrentInfo.GetDayName(deposito.Data.DayOfWeek)).FontSize(10d).Alignment = Alignment.left;
                                t.Rows.Last().Cells[3].Paragraphs.First().Append(string.Format("{0:C}", deposito.Valor)).FontSize(10d).Alignment = Alignment.left;
                                t.Rows.Last().Cells[4].Paragraphs.First().Append(string.Format("{0:C}", deposito.ValorPepino)).FontSize(10d).Alignment = Alignment.left;
                                t.Rows.Last().Cells[5].Paragraphs.First().Append(string.Format("{0:C}", deposito.Valor + deposito.ValorPepino)).FontSize(10d).Alignment = Alignment.left;

                                totalPeriodo += deposito.Valor;
                                totalPepinoPeriodo += deposito.ValorPepino;
                                totalGeralPeriodo += deposito.Valor + deposito.ValorPepino;
                            }

                            t.InsertRow();
                            t.Rows.Last().Cells[0].Paragraphs.First().Append("TOTAL PERIODO").Bold().FontSize(10d).Alignment = Alignment.right;
                            t.Rows.Last().MergeCells(0, 2);
                            t.Rows.Last().Cells[1].Paragraphs.First().Append(string.Format("{0:C}", totalPeriodo)).FontSize(10d).Alignment = Alignment.left;
                            t.Rows.Last().Cells[2].Paragraphs.First().Append(string.Format("{0:C}", totalPepinoPeriodo)).FontSize(10d).Alignment = Alignment.left;
                            t.Rows.Last().Cells[3].Paragraphs.First().Append(string.Format("{0:C}", totalGeralPeriodo)).FontSize(10d).Alignment = Alignment.left;

                            document.InsertTable(t);

                            try
                            {
                                document.Save();
                                DialogResult result = MessageBox.Show("Relatorio gerado na pasta Meus Documentos -> Relatorios(" + docPath + ")", "Atenção!", MessageBoxButtons.OK);
                            }
                            catch
                            {
                                DialogResult result = MessageBox.Show("Arquivo aberto em outro aplicativo, favor fecha-lo antes de continuar", "Atenção!", MessageBoxButtons.OK);
                            }
                        }
                        /*docForPrint.MarginLeft = 36;
                        docForPrint.MarginRight = 36;
                        docForPrint.MarginTop = 36;
                        docForPrint.MarginBottom = 36;

                        foreach (DataGridViewRow row in dgvListaImpressão.Rows)
                        {
                            string docTempPath = GerarArquivoImpressão(row);

                            if (docTempPath != "")
                            {
                                docForPrint.InsertDocument(DocX.Load(docTempPath), false);
                            }
                        }*/

                        //DialogResult result = MessageBox.Show("Relatorio gerado na pasta Meus Documentos -> Relatorios(" + docPath + ")", "Atenção!", MessageBoxButtons.OK);
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Nenhum Deposito registrado para esse Vendedor na Praça selecionada", "Atenção!", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Selecione uma Praça primeiro", "Atenção!", MessageBoxButtons.OK);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Selecione um Vendedor primeiro", "Atenção!", MessageBoxButtons.OK);
            }
        }

        #endregion

        #region Carga/Devolução

        private void btCargaDevolução_Click(object sender, EventArgs e)
        {
            if (txtIdVendedor.Text != "")
            {
                if (cbbPraça.SelectedItem != null)
                {
                    if (txtDataFinal.Text != "" && txtDataInicial.Text != "")
                    {
                        DateTime dataInicial = DateTime.Parse(txtDataInicial.Text);
                        DateTime dataFinal = DateTime.Parse(txtDataFinal.Text);

                        string query = "select * from CargaDevolução where CargaDevolução.VendedorID == " + txtIdVendedor.Text + " and date(CargaDevolução.Data) BETWEEN date('" + dataInicial.Year + "-" + dataInicial.Month.ToString("00") + "-" + dataInicial.Day.ToString("00") + "') and date('" + dataFinal.Year + "-" + dataFinal.Month.ToString("00") + "-" + dataFinal.Day.ToString("00") + "') order by CargaDevolução.Data";
                        cargaDevoluçãoList = SqliteAcessoDados.LoadQuery<CargaDevoluçãoModelo>(query);
                    }
                    else
                    {
                        cargaDevoluçãoList = SqliteAcessoDados.LoadQuery<CargaDevoluçãoModelo>("select * from CargaDevolução where CargaDevolução.VendedorID == " + txtIdVendedor.Text + " order by CargaDevolução.Data");
                    }

                    if (cargaDevoluçãoList.Count > 0)
                    {
                        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Relatorios";

                        VendedorModelo vendedor = SqliteAcessoDados.LoadQuery<VendedorModelo>("select * from Vendedor where Vendedor.ID == " + txtIdVendedor.Text).First();
                        PessoaModelo vendedorPessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select * from Pessoa where Pessoa.ID == " + vendedor.PessoaId.ToString()).First();

                        string fileName = "Cargas e Devoluções - Vendedor - " + vendedorPessoa.Nome + " - Praça - " + cbbPraça.SelectedItem.ToString() + " - ";

                        if (txtDataFinal.Text != "" && txtDataInicial.Text != "")
                        {
                            if (txtDataFinal.Text == txtDataInicial.Text)
                            {
                                fileName += DateTime.Parse(txtDataFinal.Text).Day.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Month.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Year.ToString();
                            }
                            else
                            {
                                fileName += "De - " + DateTime.Parse(txtDataFinal.Text).Day.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Month.ToString() + "_" + DateTime.Parse(txtDataFinal.Text).Year.ToString() +
                                    " - Até - " + DateTime.Parse(txtDataInicial.Text).Day.ToString() + "_" + DateTime.Parse(txtDataInicial.Text).Month.ToString() + "_" + DateTime.Parse(txtDataInicial.Text).Year.ToString();
                            }
                        }
                        else
                        {
                            fileName += "Todas as Datas";
                        }

                        fileName += ".docx";

                        System.IO.Directory.CreateDirectory(docPath);

                        docPath = System.IO.Path.Combine(docPath, fileName);

                        using (var document = DocX.Create(docPath))
                        {
                            document.InsertParagraph("SABOR MINEIRO - RELATÓRIO").FontSize(11d).Bold().Alignment = Alignment.center;
                            document.InsertParagraph("TOTAL DE VENDAS").FontSize(10d).Bold().Alignment = Alignment.center;
                            document.InsertParagraph();

                            document.InsertParagraph("PROMOTOR: ").FontSize(10d).Bold()
                                .Append(txtNomeVendedor.Text).FontSize(10d)
                                .Alignment = Alignment.left;

                            document.InsertParagraph("PRAÇA: ").FontSize(10d).Bold()
                                .Append(cbbPraça.SelectedItem.ToString()).FontSize(10d)
                                .Alignment = Alignment.left;

                            document.InsertParagraph("PLACA VEICULO: ").FontSize(10d).Bold()
                                .Append(vendedor.Placa).FontSize(10d)
                                .Alignment = Alignment.left;

                            document.InsertParagraph();

                            document.InsertParagraph("RELATÓRIO GERAL").FontSize(10d).Bold().Alignment = Alignment.center;

                            document.InsertParagraph();

                            Table t = document.AddTable(1, 4);
                            t.AutoFit = AutoFit.Contents;
                            t.Design = TableDesign.LightGridAccent3;

                            t.Rows[0].Cells[0].Paragraphs.First().Append("DATA").Bold().FontSize(10d).Alignment = Alignment.center;
                            t.Rows[0].Cells[1].Paragraphs.First().Append("PRODUTO").Bold().FontSize(10d).Alignment = Alignment.center;
                            t.Rows[0].Cells[2].Paragraphs.First().Append("CARGA/DEVOLUÇÃO").Bold().FontSize(10d).Alignment = Alignment.center;
                            t.Rows[0].Cells[3].Paragraphs.First().Append("QUANTIDADE").Bold().FontSize(10d).Alignment = Alignment.center;

                            List<ProdutosCargaDevoluçãoModelo> produtosCargaDevoluçãoList = new List<ProdutosCargaDevoluçãoModelo>();

                            foreach (CargaDevoluçãoModelo cargaDevolução in cargaDevoluçãoList)
                            {
                                produtosCargaDevoluçãoList = SqliteAcessoDados.LoadQuery<ProdutosCargaDevoluçãoModelo>("select * from ProdutosCargaDevolução where ProdutosCargaDevolução.CargaDevoluçãoID == " + cargaDevolução.Id);

                                foreach (ProdutosCargaDevoluçãoModelo produtosCargaDevolução in produtosCargaDevoluçãoList)
                                {
                                    t.InsertRow();

                                    string descrição = SqliteAcessoDados.LoadQuery<ProdutoModelo>("select Descrição from Produto where Produto.ID == " + produtosCargaDevolução.ProdutoID).First().Descrição;

                                    t.Rows.Last().Cells[0].Paragraphs.First().Append(cargaDevolução.Data.ToShortDateString()).FontSize(10d).Alignment = Alignment.left;
                                    t.Rows.Last().Cells[1].Paragraphs.First().Append(descrição).FontSize(10d).Alignment = Alignment.left;
                                    t.Rows.Last().Cells[2].Paragraphs.First().Append(cargaDevolução.Devolução ? "Devolução" : "Carga").FontSize(10d).Alignment = Alignment.left;
                                    t.Rows.Last().Cells[3].Paragraphs.First().Append(cargaDevolução.Devolução ? produtosCargaDevolução.Quantidade.ToString() : (produtosCargaDevolução.Quantidade * -1).ToString()).FontSize(10d).Alignment = Alignment.left;
                                }
                            }

                            document.InsertTable(t);

                            document.InsertParagraph();

                            document.InsertParagraph("RELATÓRIO POR PRODUTO").FontSize(10d).Bold().Alignment = Alignment.center;

                            List<ProdutoModelo> produtoList = SqliteAcessoDados.GetPesquisarTodos<ProdutoModelo>();

                            foreach (CargaDevoluçãoModelo cargaDevolução in cargaDevoluçãoList)
                            {
                                foreach (ProdutoModelo produto in produtoList)
                                {
                                    document.InsertParagraph();

                                    document.InsertParagraph("PRODUTO: ")
                                            .FontSize(10d)
                                            .Bold()
                                            .Append(produto.Descrição)
                                            .Alignment = Alignment.left;

                                    document.InsertParagraph();

                                    t = document.AddTable(1, 3);

                                    t.Rows[0].Cells[0].Paragraphs.First().Append("DATA").Bold().FontSize(10d).Alignment = Alignment.center;
                                    t.Rows[0].Cells[1].Paragraphs.First().Append("CARGA/DEVOLUÇÃO").Bold().FontSize(10d).Alignment = Alignment.center;
                                    t.Rows[0].Cells[2].Paragraphs.First().Append("QUANTIDADE").Bold().FontSize(10d).Alignment = Alignment.center;

                                    produtosCargaDevoluçãoList = SqliteAcessoDados.LoadQuery<ProdutosCargaDevoluçãoModelo>("select * from ProdutosCargaDevolução where ProdutosCargaDevolução.CargaDevoluçãoID == " + cargaDevolução.Id + " and ProdutosCargaDevolução.ProdutoID == " + produto.Id);

                                    int quantidade = 0;

                                    foreach (ProdutosCargaDevoluçãoModelo produtosCargaDevolução in produtosCargaDevoluçãoList)
                                    {
                                        t.InsertRow();

                                        string descrição = SqliteAcessoDados.LoadQuery<ProdutoModelo>("select Descrição from Produto where Produto.ID == " + produtosCargaDevolução.ProdutoID).First().Descrição;

                                        t.Rows.Last().Cells[0].Paragraphs.First().Append(cargaDevolução.Data.ToShortDateString()).FontSize(10d).Alignment = Alignment.left;
                                        t.Rows.Last().Cells[1].Paragraphs.First().Append(cargaDevolução.Devolução ? "Devolução" : "Carga").FontSize(10d).Alignment = Alignment.left;
                                        t.Rows.Last().Cells[2].Paragraphs.First().Append(cargaDevolução.Devolução ? produtosCargaDevolução.Quantidade.ToString() : (produtosCargaDevolução.Quantidade * -1).ToString()).FontSize(10d).Alignment = Alignment.left;

                                        quantidade += cargaDevolução.Devolução ? produtosCargaDevolução.Quantidade : (produtosCargaDevolução.Quantidade * -1);
                                    }

                                    t.InsertRow();

                                    t.Rows.Last().Cells[1].Paragraphs.First().Append("TOTAL PERIODO").Bold().FontSize(10d).Alignment = Alignment.left;
                                    t.Rows.Last().Cells[2].Paragraphs.First().Append(quantidade.ToString()).FontSize(10d).Alignment = Alignment.left;

                                    document.InsertTable(t);
                                }                                
                            }

                            document.Save();

                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Nenhum registro encontrado nas datas selecionadas para este vendedor e esta praça", "Atenção!", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Selecione uma Praça primeiro", "Atenção!", MessageBoxButtons.OK);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Selecione um Vendedor primeiro", "Atenção!", MessageBoxButtons.OK);
            }
        }

        #endregion
    }
}
