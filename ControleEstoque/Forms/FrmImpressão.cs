using ControleEstoqueLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace ControleEstoque
{
    public partial class FrmImpressão : Form
    {
        public FrmImpressão()
        {
            InitializeComponent();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            if (txtIdVendedor.Text != "")
            {
                if (cbbPraça.SelectedItem != null)
                {
                    if (dgvListaImpressão.Rows.Count > 0)
                    {
                        string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Impressões";
                        string fileName = "Pedidos para Impressão - " + cbbPraça.SelectedItem.ToString() + ".docx";

                        System.IO.Directory.CreateDirectory(docPath);

                        docPath = System.IO.Path.Combine(docPath, fileName);

                        DocX docForPrint = DocX.Create(docPath);
                        docForPrint.MarginLeft = 36;
                        docForPrint.MarginRight = 36;
                        docForPrint.MarginTop = 36;
                        docForPrint.MarginBottom = 36;

                        foreach (DataGridViewRow row in dgvListaImpressão.Rows)
                        {
                            if (bool.Parse(row.Cells["cbImprimir"].Value.ToString()))
                            {
                                string docTempPath = GerarArquivoImpressão(row);

                                if (docTempPath != "")
                                {
                                    docForPrint.InsertDocument(DocX.Load(docTempPath), false);
                                }
                            }
                        }

                        DialogResult result = MessageBox.Show("Relatorio gerado na pasta Meus Documentos -> Impressões ( " + (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Impressões)"), "Atenção!", MessageBoxButtons.OK);

                        /*ProcessStartInfo info = new ProcessStartInfo(docPath);

                        info.Verb = "Print";

                        info.CreateNoWindow = false;

                        info.WindowStyle = ProcessWindowStyle.Normal;
                        
                        Process.Start(info);
                        

                        PrintDialog printDlg = new PrintDialog();
                        PrintDocument printDoc = new PrintDocument();
                        printDoc.DocumentName = docPath;
                        printDlg.Document = printDoc;
                        printDlg.AllowSelection = true;
                        printDlg.AllowSomePages = true;
                        //Call ShowDialog
                        if (printDlg.ShowDialog() == DialogResult.OK)
                        {
                            printDoc.Print();
                        }*/
                        if (dgvListaImpressão.Rows.Count > 1)
                        {
                            docForPrint.Save();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Lista de Clientes para Impressão vazia", "Atenção!", MessageBoxButtons.OK);
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

        private string GerarArquivoImpressão(DataGridViewRow row)
        {
            string id = row.Cells["txtCodigo"].Value.ToString();
            string nome = row.Cells["txtNome"].Value.ToString();
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Impressões";
            string fileName = "Pedido - " + id + " - " + nome + ".docx";

            System.IO.Directory.CreateDirectory(docPath);

            docPath = System.IO.Path.Combine(docPath, fileName);

            PessoaModelo pessoa = SqliteAcessoDados.LoadQuery<PessoaModelo>("select * from Pessoa where Pessoa.ID == " + id).First();

            using (var document = DocX.Create(docPath))
            {

                document.MarginLeft = 36; // 1cm = 28.3464567pt
                document.MarginRight = 36;
                document.MarginTop = 36;
                document.MarginBottom = 36;
                document.InsertParagraph("SABOR MINEIRO - PEDIDO").FontSize(11d).Bold().Alignment = Alignment.center;
                document.InsertParagraph();

                document.InsertParagraph("NOME: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(pessoa.Nome + "     ")//"________________________________________________________________") // adicionar logicas \/
                    .FontSize(10d)
                    .Append("DATA DE NASCIMENTO: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(pessoa.Nascimento.ToShortDateString())//"___ / ___ / ___")
                    .FontSize(10d)
                    .Alignment = Alignment.left;

                document.InsertParagraph("RG: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(pessoa.RG + "     ") //"_______________________________ ")
                    .FontSize(10d)
                    .Append("CPF: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(pessoa.CPF + "     ") //"______________________________")
                    .FontSize(10d)
                    .Append("TELEFONE: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(pessoa.Telefone ) //"(___)_____________________")
                    .FontSize(10d)
                    .Alignment = Alignment.left;

                document.InsertParagraph("INDICACÃO: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(pessoa.PontoReferencia + "     ") //"______________________________________________________________________________________________")
                    .FontSize(10d)
                    .Alignment = Alignment.left;

                document.InsertParagraph("ENDEREÇO: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(pessoa.Endereco + " " + pessoa.Numero + "     ") //"_____________________________________________________________________________________________")
                    .FontSize(10d)
                    .Alignment = Alignment.left;

                document.InsertParagraph("BAIRRO: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(pessoa.Bairro + "     ") //"____________________________________________________________")
                    .FontSize(10d)
                    .Append("CIDADE: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(pessoa.Cidade + " - " + pessoa.Estado + "     ") //"______________________________")
                    .FontSize(10d)
                    .Alignment = Alignment.left;

                document.InsertParagraph("VENDEDOR: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(txtNomeVendedor.Text + "     ") //"__ __________")
                    .FontSize(10d)
                    .Append("TELEFONE: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(txtTelefoneVendedor.Text + "     ") //"(___)_____________________")
                    .FontSize(10d)
                    .Append("PRAÇA: ")
                    .Bold()
                    .FontSize(10d)
                    .Append(cbbPraça.Text + "     ") //"__ - ___________")
                    .FontSize(10d)
                    .Alignment = Alignment.left;

                document.InsertParagraph();

                Table t = document.AddTable(11, 7);
                t.Design = TableDesign.LightGridAccent3;
                t.Alignment = Alignment.center;
                t.AutoFit = AutoFit.Contents;

                t.Rows[0].Cells[0].Paragraphs.First().Append("PRODUTO").FontSize(10d).Alignment = Alignment.center;
                t.Rows[0].Cells[1].Paragraphs.First().Append("ENTREGUE").FontSize(10d).Alignment = Alignment.center;
                t.Rows[0].MergeCells(1, 2);
                t.Rows[0].Cells[2].Paragraphs.First().Append("DEVOLVIDO").FontSize(10d).Alignment = Alignment.center;
                t.Rows[0].Cells[3].Paragraphs.First().Append("VENDIDO").FontSize(10d).Alignment = Alignment.center;
                t.Rows[0].Cells[4].Paragraphs.First().Append("VALOR UNIT").FontSize(10d).Alignment = Alignment.center;
                t.Rows[0].Cells[5].Paragraphs.First().Append("TOTAL").FontSize(10d).Alignment = Alignment.center;

                t.Rows[1].Cells[0].Paragraphs.First().Append("CONE").FontSize(10d);
                t.Rows[2].Cells[0].Paragraphs.First().Append("BISCOITO").FontSize(10d);
                t.Rows[3].Cells[0].Paragraphs.First().Append("DOCE DE LEITE / COCADA CREMOSA").FontSize(10d);
                t.Rows[4].Cells[0].Paragraphs.First().Append("MEL").FontSize(10d);
                t.Rows[5].Cells[0].Paragraphs.First().Append("PAÇOCA / PÉ DE MOÇA").FontSize(10d);
                t.Rows[6].Cells[0].Paragraphs.First().Append("TRUFA").FontSize(10d);
                t.Rows[7].Cells[0].Paragraphs.First().Append("PICADINHO").FontSize(10d);
                t.Rows[8].Cells[0].Paragraphs.First().Append("QUEIJO").FontSize(10d);


                /*foreach (Row tableRow in t.Rows)
                {
                    for (int i = 0; i < tableRow.Cells.Count; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                tableRow.Cells[i].Width = 5.89 * 28.3464567;
                                break;
                            case 1:
                                tableRow.Cells[i].Width = 2.59 * 28.3464567;
                                break;
                            case 2:
                                tableRow.Cells[i].Width = 2.59 * 28.3464567;
                                break;
                            case 3:
                                tableRow.Cells[i].Width = 1.18 * 28.3464567;
                                break;
                            case 4:
                                tableRow.Cells[i].Width = 1.18 * 28.3464567;
                                break;
                            case 5:
                                tableRow.Cells[i].Width = 2.12 * 28.3464567;
                                break;
                            case 6:
                                tableRow.Cells[i].Width = 6.6 * 28.3464567;
                                break;
                            default:
                                break;
                        }
                    }
                }

                t.SetColumnWidth(0, );
                t.SetColumnWidth(1, );
                t.SetColumnWidth(2, 2.59 * 28.3464567);
                t.SetColumnWidth(3, );
                t.SetColumnWidth(4, 1.18 * 28.3464567);
                t.SetColumnWidth(5, );
                t.SetColumnWidth(6, );*/

                t.Rows[9].Height = 61.228346472;
                t.Rows[10].Height = 61.228346472;

                t.Rows[9].MergeCells(0, 5);
                t.Rows[10].MergeCells(0, 5);
                t.MergeCellsInColumn(0, 9, 10);

                t.Rows[9].Cells[0].InsertParagraph("TOTAL DE PEÇAS: ______________________ N° DE ITENS _").FontSize(10d)
                    .InsertParagraphAfterSelf("OBS > ATÉ R$ 89,99 (20 %) COMISSÃO / ATÉ R$ 169,99 (25 %) COMISSÃO / ATÉ R$ 600,00 (30 %) COMISSÃO / ACIMA DE R$ 600,00 (35 %) COMISSÃO / ACIMA DE R$ 990,00 (40 %) COMISSÃO").FontSize(10d)
                    .InsertParagraphAfterSelf("        *	NÃO TRABALHAMOS COM DEPÓSITOS EM CONTA BANCÁRIA, NEM CHEQUES").Bold().FontSize(10d)
                    .InsertParagraphAfterSelf("        *	NÃO TRABALHAMOS COM BRINDES").Bold().FontSize(10d)
                    .InsertParagraphAfterSelf("DATA DE RETORNO DIA   ______ / ______ / ______").FontSize(10d)
                    .InsertParagraphAfterSelf("                                                            _________________________________").FontSize(10d)
                    .InsertParagraphAfterSelf("                                                                                      ASSINATURA").FontSize(10d);

                document.InsertTable(t);

                document.InsertParagraph("EMPRESA FILIADA AO SPC / PAGUE EM DIA E MANTENHA SEU NOME LIMPO").Bold().FontSize(10d);
                //document.InsertParagraph();

                try
                {
                    document.Save();
                    return docPath;
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Arquivo aberto em outro aplicativo, favor fecha-lo antes de continuar", "Atenção!", MessageBoxButtons.OK);
                    return "";
                }
            }
        }

        private void btPraça_Click(object sender, EventArgs e)
        {
            if (cbbPraça.SelectedItem != null)
            {
                List<PessoaModelo> pessoaList = SqliteAcessoDados.LoadQuery<PessoaModelo>("select * from Pessoa where Pessoa.PraçaID == " + int.Parse(cbbPraça.SelectedItem.ToString().Split('-').First()) + " and Ativo == 1 and Cliente == 1");
                int total = 0;
                dgvListaImpressão.Rows.Clear();

                foreach (PessoaModelo pessoa in pessoaList)
                {
                    dgvListaImpressão.Rows.Add(true, pessoa.Id, pessoa.Nome);
                    total++;
                }

                txtTotal.Text = total.ToString();
            }
            else
            {
                DialogResult result = MessageBox.Show("Selecione uma Praça primeiro", "Atenção!", MessageBoxButtons.OK);
            }
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
                    txtTelefoneVendedor.Text = SqliteAcessoDados.LoadQuery<PessoaModelo>("select Telefone from Pessoa where Pessoa.ID == " + ResultadoPesquisaVendedor.PessoaId.ToString())[0].Telefone.ToString();

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

        private void btPessoa_Click(object sender, EventArgs e)
        {
            using (var form = new FrmProcura(this.Name, "Pessoa", FrmPessoas.parameters))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var ResultadoPesquisaPessoa = form.TableObjectPessoa[form.ResultID];

                    dgvListaImpressão.Rows.Clear();

                    dgvListaImpressão.Rows.Add(true, ResultadoPesquisaPessoa.Id, ResultadoPesquisaPessoa.Nome);
                    txtTotal.Text = "1";
                }
            }
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            dgvListaImpressão.Rows.Clear();
        }
    }
}
