namespace ControleEstoque
{
    partial class FrmVendedores
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
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btSearchPessoa = new System.Windows.Forms.Button();
            this.btLimpar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btSearchPraça = new System.Windows.Forms.Button();
            this.txtIdPessoa = new System.Windows.Forms.TextBox();
            this.txtNomePessoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdPraça = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPraça = new System.Windows.Forms.TextBox();
            this.btAlterar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.btUltimo = new System.Windows.Forms.Button();
            this.btProximo = new System.Windows.Forms.Button();
            this.btAnterior = new System.Windows.Forms.Button();
            this.btPrimeiro = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(88, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Código Pessoa";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Código Praça";
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
            // btSearchPessoa
            // 
            this.btSearchPessoa.FlatAppearance.BorderSize = 0;
            this.btSearchPessoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearchPessoa.Image = global::ControleEstoque.Properties.Resources.search_16;
            this.btSearchPessoa.Location = new System.Drawing.Point(170, 68);
            this.btSearchPessoa.Name = "btSearchPessoa";
            this.btSearchPessoa.Size = new System.Drawing.Size(21, 21);
            this.btSearchPessoa.TabIndex = 8;
            this.btSearchPessoa.UseVisualStyleBackColor = true;
            this.btSearchPessoa.Click += new System.EventHandler(this.btSearchPessoa_Click);
            // 
            // btLimpar
            // 
            this.btLimpar.FlatAppearance.BorderSize = 0;
            this.btLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpar.Image = global::ControleEstoque.Properties.Resources.delete_sign;
            this.btLimpar.Location = new System.Drawing.Point(53, 145);
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
            this.btSalvar.Location = new System.Drawing.Point(12, 145);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(35, 31);
            this.btSalvar.TabIndex = 45;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // txtPlaca
            // 
            this.txtPlaca.Location = new System.Drawing.Point(461, 111);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(100, 20);
            this.txtPlaca.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(458, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Placa";
            // 
            // btSearchPraça
            // 
            this.btSearchPraça.FlatAppearance.BorderSize = 0;
            this.btSearchPraça.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearchPraça.Image = global::ControleEstoque.Properties.Resources.search_16;
            this.btSearchPraça.Location = new System.Drawing.Point(91, 110);
            this.btSearchPraça.Name = "btSearchPraça";
            this.btSearchPraça.Size = new System.Drawing.Size(21, 21);
            this.btSearchPraça.TabIndex = 56;
            this.btSearchPraça.UseVisualStyleBackColor = true;
            this.btSearchPraça.Click += new System.EventHandler(this.btSearchPraça_Click);
            // 
            // txtIdPessoa
            // 
            this.txtIdPessoa.Enabled = false;
            this.txtIdPessoa.Location = new System.Drawing.Point(91, 68);
            this.txtIdPessoa.Name = "txtIdPessoa";
            this.txtIdPessoa.Size = new System.Drawing.Size(73, 20);
            this.txtIdPessoa.TabIndex = 58;
            // 
            // txtNomePessoa
            // 
            this.txtNomePessoa.Location = new System.Drawing.Point(197, 69);
            this.txtNomePessoa.Name = "txtNomePessoa";
            this.txtNomePessoa.Size = new System.Drawing.Size(364, 20);
            this.txtNomePessoa.TabIndex = 59;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Nome";
            // 
            // txtIdPraça
            // 
            this.txtIdPraça.Enabled = false;
            this.txtIdPraça.Location = new System.Drawing.Point(12, 111);
            this.txtIdPraça.Name = "txtIdPraça";
            this.txtIdPraça.Size = new System.Drawing.Size(73, 20);
            this.txtIdPraça.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Praça";
            // 
            // txtPraça
            // 
            this.txtPraça.Location = new System.Drawing.Point(118, 111);
            this.txtPraça.Name = "txtPraça";
            this.txtPraça.Size = new System.Drawing.Size(324, 20);
            this.txtPraça.TabIndex = 62;
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
            this.panel1.Size = new System.Drawing.Size(588, 47);
            this.panel1.TabIndex = 64;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 188);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPraça);
            this.Controls.Add(this.txtIdPraça);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomePessoa);
            this.Controls.Add(this.txtIdPessoa);
            this.Controls.Add(this.btSearchPraça);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSearchPessoa);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btLimpar);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.label11);
            this.Name = "FrmVendedores";
            this.Text = "Vendedor";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btLimpar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btSearchPessoa;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSearchPraça;
        private System.Windows.Forms.TextBox txtIdPessoa;
        private System.Windows.Forms.TextBox txtNomePessoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdPraça;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPraça;
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
    }
}