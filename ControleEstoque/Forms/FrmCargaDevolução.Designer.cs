namespace ControleEstoque
{
    partial class FrmCargaDevolução
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAlterar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.btUltimo = new System.Windows.Forms.Button();
            this.btProximo = new System.Windows.Forms.Button();
            this.btAnterior = new System.Windows.Forms.Button();
            this.btPrimeiro = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.btLimpar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btAddItem = new System.Windows.Forms.Button();
            this.btRemoverItem = new System.Windows.Forms.Button();
            this.cbbPraça = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomeVendedor = new System.Windows.Forms.TextBox();
            this.txtIdVendedor = new System.Windows.Forms.TextBox();
            this.btSearchVendedor = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cbbDevolução = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Código";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(12, 68);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(73, 20);
            this.txtID.TabIndex = 52;
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(12, 108);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(100, 20);
            this.txtPlaca.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Placa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Produtos";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btAlterar);
            this.panel1.Controls.Add(this.btExcluir);
            this.panel1.Controls.Add(this.btAdd);
            this.panel1.Controls.Add(this.btPesquisar);
            this.panel1.Controls.Add(this.btUltimo);
            this.panel1.Controls.Add(this.btProximo);
            this.panel1.Controls.Add(this.btAnterior);
            this.panel1.Controls.Add(this.btPrimeiro);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(668, 47);
            this.panel1.TabIndex = 64;
            // 
            // btAlterar
            // 
            this.btAlterar.FlatAppearance.BorderSize = 0;
            this.btAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAlterar.Image = global::ControleEstoque.Properties.Resources.icons8_edit_30;
            this.btAlterar.Location = new System.Drawing.Point(240, 7);
            this.btAlterar.Margin = new System.Windows.Forms.Padding(0);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(35, 31);
            this.btAlterar.TabIndex = 8;
            this.btAlterar.UseVisualStyleBackColor = true;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.FlatAppearance.BorderSize = 0;
            this.btExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExcluir.Image = global::ControleEstoque.Properties.Resources.minus;
            this.btExcluir.Location = new System.Drawing.Point(281, 7);
            this.btExcluir.Margin = new System.Windows.Forms.Padding(0);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(35, 31);
            this.btExcluir.TabIndex = 7;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAdd
            // 
            this.btAdd.FlatAppearance.BorderSize = 0;
            this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAdd.Image = global::ControleEstoque.Properties.Resources.plus;
            this.btAdd.Location = new System.Drawing.Point(199, 7);
            this.btAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(35, 31);
            this.btAdd.TabIndex = 6;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btPesquisar
            // 
            this.btPesquisar.FlatAppearance.BorderSize = 0;
            this.btPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPesquisar.Image = global::ControleEstoque.Properties.Resources.search;
            this.btPesquisar.Location = new System.Drawing.Point(350, 7);
            this.btPesquisar.Margin = new System.Windows.Forms.Padding(0);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(35, 31);
            this.btPesquisar.TabIndex = 5;
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // btUltimo
            // 
            this.btUltimo.FlatAppearance.BorderSize = 0;
            this.btUltimo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUltimo.Image = global::ControleEstoque.Properties.Resources.last;
            this.btUltimo.Location = new System.Drawing.Point(132, 7);
            this.btUltimo.Margin = new System.Windows.Forms.Padding(0);
            this.btUltimo.Name = "btUltimo";
            this.btUltimo.Size = new System.Drawing.Size(35, 31);
            this.btUltimo.TabIndex = 4;
            this.btUltimo.UseVisualStyleBackColor = true;
            this.btUltimo.Click += new System.EventHandler(this.btUltimo_Click);
            // 
            // btProximo
            // 
            this.btProximo.FlatAppearance.BorderSize = 0;
            this.btProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btProximo.Image = global::ControleEstoque.Properties.Resources.next;
            this.btProximo.Location = new System.Drawing.Point(91, 7);
            this.btProximo.Margin = new System.Windows.Forms.Padding(0);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(35, 31);
            this.btProximo.TabIndex = 3;
            this.btProximo.UseVisualStyleBackColor = true;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click);
            // 
            // btAnterior
            // 
            this.btAnterior.FlatAppearance.BorderSize = 0;
            this.btAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAnterior.Image = global::ControleEstoque.Properties.Resources.previous;
            this.btAnterior.Location = new System.Drawing.Point(51, 7);
            this.btAnterior.Margin = new System.Windows.Forms.Padding(0);
            this.btAnterior.Name = "btAnterior";
            this.btAnterior.Size = new System.Drawing.Size(35, 31);
            this.btAnterior.TabIndex = 2;
            this.btAnterior.UseVisualStyleBackColor = true;
            this.btAnterior.Click += new System.EventHandler(this.btAnterior_Click);
            // 
            // btPrimeiro
            // 
            this.btPrimeiro.FlatAppearance.BorderSize = 0;
            this.btPrimeiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrimeiro.Image = global::ControleEstoque.Properties.Resources.first;
            this.btPrimeiro.Location = new System.Drawing.Point(11, 7);
            this.btPrimeiro.Margin = new System.Windows.Forms.Padding(0);
            this.btPrimeiro.Name = "btPrimeiro";
            this.btPrimeiro.Size = new System.Drawing.Size(35, 31);
            this.btPrimeiro.TabIndex = 1;
            this.btPrimeiro.UseVisualStyleBackColor = true;
            this.btPrimeiro.Click += new System.EventHandler(this.btPrimeiro_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToResizeRows = false;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCodigo,
            this.txtNomeProduto,
            this.txtQuantidade});
            this.dgvProdutos.Location = new System.Drawing.Point(11, 147);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(630, 113);
            this.dgvProdutos.TabIndex = 65;
            // 
            // btLimpar
            // 
            this.btLimpar.FlatAppearance.BorderSize = 0;
            this.btLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpar.Image = global::ControleEstoque.Properties.Resources.delete_sign;
            this.btLimpar.Location = new System.Drawing.Point(49, 297);
            this.btLimpar.Name = "btLimpar";
            this.btLimpar.Size = new System.Drawing.Size(35, 31);
            this.btLimpar.TabIndex = 46;
            this.btLimpar.UseVisualStyleBackColor = true;
            this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.FlatAppearance.BorderSize = 0;
            this.btSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSalvar.Image = global::ControleEstoque.Properties.Resources.save;
            this.btSalvar.Location = new System.Drawing.Point(8, 297);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(35, 31);
            this.btSalvar.TabIndex = 45;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btAddItem
            // 
            this.btAddItem.FlatAppearance.BorderSize = 0;
            this.btAddItem.Location = new System.Drawing.Point(13, 266);
            this.btAddItem.Name = "btAddItem";
            this.btAddItem.Size = new System.Drawing.Size(75, 23);
            this.btAddItem.TabIndex = 56;
            this.btAddItem.Text = "Adicionar";
            this.btAddItem.UseVisualStyleBackColor = true;
            this.btAddItem.Click += new System.EventHandler(this.btAddItem_Click);
            // 
            // btRemoverItem
            // 
            this.btRemoverItem.Location = new System.Drawing.Point(94, 266);
            this.btRemoverItem.Name = "btRemoverItem";
            this.btRemoverItem.Size = new System.Drawing.Size(75, 23);
            this.btRemoverItem.TabIndex = 66;
            this.btRemoverItem.Text = "Remover";
            this.btRemoverItem.UseVisualStyleBackColor = true;
            this.btRemoverItem.Click += new System.EventHandler(this.btRemoverItem_Click);
            // 
            // cbbPraça
            // 
            this.cbbPraça.FormattingEnabled = true;
            this.cbbPraça.Location = new System.Drawing.Point(118, 107);
            this.cbbPraça.Name = "cbbPraça";
            this.cbbPraça.Size = new System.Drawing.Size(121, 21);
            this.cbbPraça.TabIndex = 95;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(116, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 94;
            this.label6.Text = "Praça";
            // 
            // txtNomeVendedor
            // 
            this.txtNomeVendedor.Enabled = false;
            this.txtNomeVendedor.Location = new System.Drawing.Point(196, 68);
            this.txtNomeVendedor.Name = "txtNomeVendedor";
            this.txtNomeVendedor.Size = new System.Drawing.Size(445, 20);
            this.txtNomeVendedor.TabIndex = 93;
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.Enabled = false;
            this.txtIdVendedor.Location = new System.Drawing.Point(91, 68);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(73, 20);
            this.txtIdVendedor.TabIndex = 92;
            // 
            // btSearchVendedor
            // 
            this.btSearchVendedor.FlatAppearance.BorderSize = 0;
            this.btSearchVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearchVendedor.Image = global::ControleEstoque.Properties.Resources.search_16;
            this.btSearchVendedor.Location = new System.Drawing.Point(169, 67);
            this.btSearchVendedor.Name = "btSearchVendedor";
            this.btSearchVendedor.Size = new System.Drawing.Size(21, 21);
            this.btSearchVendedor.TabIndex = 90;
            this.btSearchVendedor.UseVisualStyleBackColor = true;
            this.btSearchVendedor.Click += new System.EventHandler(this.btSearchVendedor_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(91, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 91;
            this.label12.Text = "Código Vendedor";
            // 
            // cbbDevolução
            // 
            this.cbbDevolução.FormattingEnabled = true;
            this.cbbDevolução.Items.AddRange(new object[] {
            "Carga",
            "Devolução"});
            this.cbbDevolução.Location = new System.Drawing.Point(245, 108);
            this.cbbDevolução.Name = "cbbDevolução";
            this.cbbDevolução.Size = new System.Drawing.Size(121, 21);
            this.cbbDevolução.TabIndex = 97;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Tipo";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(372, 109);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(100, 20);
            this.txtData.TabIndex = 99;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(369, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "Data";
            // 
            // txtCodigo
            // 
            this.txtCodigo.HeaderText = "Código";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.HeaderText = "Produto";
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.ReadOnly = true;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.HeaderText = "Quantidade";
            this.txtQuantidade.Name = "txtQuantidade";
            // 
            // FrmCargaDevolução
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 340);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbbDevolução);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbPraça);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNomeVendedor);
            this.Controls.Add(this.txtIdVendedor);
            this.Controls.Add(this.btSearchVendedor);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btRemoverItem);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btAddItem);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLimpar);
            this.Controls.Add(this.btSalvar);
            this.Name = "FrmCargaDevolução";
            this.Text = "Carga/Devolução";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btLimpar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btAlterar;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.Button btUltimo;
        private System.Windows.Forms.Button btProximo;
        private System.Windows.Forms.Button btAnterior;
        private System.Windows.Forms.Button btPrimeiro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Button btRemoverItem;
        private System.Windows.Forms.Button btAddItem;
        private System.Windows.Forms.ComboBox cbbPraça;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNomeVendedor;
        private System.Windows.Forms.TextBox txtIdVendedor;
        private System.Windows.Forms.Button btSearchVendedor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbDevolução;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantidade;
    }
}