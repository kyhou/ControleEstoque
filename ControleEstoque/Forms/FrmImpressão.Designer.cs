namespace ControleEstoque
{
    partial class FrmImpressão
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
            this.btPraça = new System.Windows.Forms.Button();
            this.dgvListaImpressão = new System.Windows.Forms.DataGridView();
            this.cbImprimir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbbPraça = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTelefoneVendedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeVendedor = new System.Windows.Forms.TextBox();
            this.txtIdVendedor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btPessoa = new System.Windows.Forms.Button();
            this.btLimpar = new System.Windows.Forms.Button();
            this.btSearchVendedor = new System.Windows.Forms.Button();
            this.btImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaImpressão)).BeginInit();
            this.SuspendLayout();
            // 
            // btPraça
            // 
            this.btPraça.Location = new System.Drawing.Point(12, 52);
            this.btPraça.Name = "btPraça";
            this.btPraça.Size = new System.Drawing.Size(75, 23);
            this.btPraça.TabIndex = 1;
            this.btPraça.Text = "Por Praça";
            this.btPraça.UseVisualStyleBackColor = true;
            this.btPraça.Click += new System.EventHandler(this.btPraça_Click);
            // 
            // dgvListaImpressão
            // 
            this.dgvListaImpressão.AllowUserToAddRows = false;
            this.dgvListaImpressão.AllowUserToDeleteRows = false;
            this.dgvListaImpressão.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaImpressão.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cbImprimir,
            this.txtCodigo,
            this.txtNome});
            this.dgvListaImpressão.Location = new System.Drawing.Point(12, 94);
            this.dgvListaImpressão.Name = "dgvListaImpressão";
            this.dgvListaImpressão.Size = new System.Drawing.Size(776, 283);
            this.dgvListaImpressão.TabIndex = 2;
            // 
            // cbImprimir
            // 
            this.cbImprimir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cbImprimir.HeaderText = "Imprimir";
            this.cbImprimir.Name = "cbImprimir";
            this.cbImprimir.Width = 48;
            // 
            // txtCodigo
            // 
            this.txtCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.txtCodigo.HeaderText = "Código";
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Width = 65;
            // 
            // txtNome
            // 
            this.txtNome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.txtNome.HeaderText = "Nome Cliente";
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Width = 95;
            // 
            // cbbPraça
            // 
            this.cbbPraça.FormattingEnabled = true;
            this.cbbPraça.Location = new System.Drawing.Point(569, 26);
            this.cbbPraça.Name = "cbbPraça";
            this.cbbPraça.Size = new System.Drawing.Size(121, 21);
            this.cbbPraça.TabIndex = 97;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(693, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 96;
            this.label13.Text = "Telefone";
            // 
            // txtTelefoneVendedor
            // 
            this.txtTelefoneVendedor.Enabled = false;
            this.txtTelefoneVendedor.Location = new System.Drawing.Point(696, 27);
            this.txtTelefoneVendedor.Name = "txtTelefoneVendedor";
            this.txtTelefoneVendedor.Size = new System.Drawing.Size(100, 20);
            this.txtTelefoneVendedor.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(567, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 94;
            this.label1.Text = "Praça";
            // 
            // txtNomeVendedor
            // 
            this.txtNomeVendedor.Enabled = false;
            this.txtNomeVendedor.Location = new System.Drawing.Point(118, 26);
            this.txtNomeVendedor.Name = "txtNomeVendedor";
            this.txtNomeVendedor.Size = new System.Drawing.Size(445, 20);
            this.txtNomeVendedor.TabIndex = 93;
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.Enabled = false;
            this.txtIdVendedor.Location = new System.Drawing.Point(12, 26);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(73, 20);
            this.txtIdVendedor.TabIndex = 92;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 91;
            this.label12.Text = "Código Vendedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 98;
            this.label2.Text = "Clientes";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(12, 405);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 100;
            this.label3.Text = "Total";
            // 
            // btPessoa
            // 
            this.btPessoa.Location = new System.Drawing.Point(93, 52);
            this.btPessoa.Name = "btPessoa";
            this.btPessoa.Size = new System.Drawing.Size(75, 23);
            this.btPessoa.TabIndex = 101;
            this.btPessoa.Text = "Por Pessoa";
            this.btPessoa.UseVisualStyleBackColor = true;
            this.btPessoa.Click += new System.EventHandler(this.btPessoa_Click);
            // 
            // btLimpar
            // 
            this.btLimpar.FlatAppearance.BorderSize = 0;
            this.btLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpar.Image = global::ControleEstoque.Properties.Resources.icons8_broom_30;
            this.btLimpar.Location = new System.Drawing.Point(744, 389);
            this.btLimpar.Name = "btLimpar";
            this.btLimpar.Size = new System.Drawing.Size(35, 31);
            this.btLimpar.TabIndex = 102;
            this.btLimpar.UseVisualStyleBackColor = true;
            this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
            // 
            // btSearchVendedor
            // 
            this.btSearchVendedor.FlatAppearance.BorderSize = 0;
            this.btSearchVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearchVendedor.Image = global::ControleEstoque.Properties.Resources.search_16;
            this.btSearchVendedor.Location = new System.Drawing.Point(90, 25);
            this.btSearchVendedor.Name = "btSearchVendedor";
            this.btSearchVendedor.Size = new System.Drawing.Size(21, 21);
            this.btSearchVendedor.TabIndex = 90;
            this.btSearchVendedor.UseVisualStyleBackColor = true;
            this.btSearchVendedor.Click += new System.EventHandler(this.btSearchVendedor_Click);
            // 
            // btImprimir
            // 
            this.btImprimir.FlatAppearance.BorderSize = 0;
            this.btImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btImprimir.Image = global::ControleEstoque.Properties.Resources.icons8_send_to_printer_30;
            this.btImprimir.Location = new System.Drawing.Point(15, 434);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(35, 31);
            this.btImprimir.TabIndex = 0;
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // FrmImpressão
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.btLimpar);
            this.Controls.Add(this.btPessoa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbPraça);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTelefoneVendedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeVendedor);
            this.Controls.Add(this.txtIdVendedor);
            this.Controls.Add(this.btSearchVendedor);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dgvListaImpressão);
            this.Controls.Add(this.btPraça);
            this.Controls.Add(this.btImprimir);
            this.Name = "FrmImpressão";
            this.Text = "FrmImpressão";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaImpressão)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.Button btPraça;
        private System.Windows.Forms.DataGridView dgvListaImpressão;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cbImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNome;
        private System.Windows.Forms.ComboBox cbbPraça;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTelefoneVendedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeVendedor;
        private System.Windows.Forms.TextBox txtIdVendedor;
        private System.Windows.Forms.Button btSearchVendedor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btPessoa;
        private System.Windows.Forms.Button btLimpar;
    }
}