namespace ControleEstoque
{
    partial class FrmRelatorios
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
            this.btComissões = new System.Windows.Forms.Button();
            this.btTotalVendas = new System.Windows.Forms.Button();
            this.btCargaDevolução = new System.Windows.Forms.Button();
            this.btDepositos = new System.Windows.Forms.Button();
            this.txtNomeVendedor = new System.Windows.Forms.TextBox();
            this.txtIdVendedor = new System.Windows.Forms.TextBox();
            this.btSearchVendedor = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataInicial = new System.Windows.Forms.TextBox();
            this.txtDataFinal = new System.Windows.Forms.TextBox();
            this.btEstoque = new System.Windows.Forms.Button();
            this.cbbPraça = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btComissões
            // 
            this.btComissões.BackColor = System.Drawing.Color.Transparent;
            this.btComissões.Enabled = false;
            this.btComissões.FlatAppearance.BorderSize = 0;
            this.btComissões.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btComissões.Image = global::ControleEstoque.Properties.Resources.budget;
            this.btComissões.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btComissões.Location = new System.Drawing.Point(69, 107);
            this.btComissões.Margin = new System.Windows.Forms.Padding(0);
            this.btComissões.Name = "btComissões";
            this.btComissões.Size = new System.Drawing.Size(65, 60);
            this.btComissões.TabIndex = 6;
            this.btComissões.Text = "Comissões";
            this.btComissões.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btComissões.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btComissões.UseVisualStyleBackColor = false;
            // 
            // btTotalVendas
            // 
            this.btTotalVendas.BackColor = System.Drawing.Color.Transparent;
            this.btTotalVendas.FlatAppearance.BorderSize = 0;
            this.btTotalVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTotalVendas.Image = global::ControleEstoque.Properties.Resources.icons8_push_cart_40;
            this.btTotalVendas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btTotalVendas.Location = new System.Drawing.Point(9, 107);
            this.btTotalVendas.Margin = new System.Windows.Forms.Padding(0);
            this.btTotalVendas.Name = "btTotalVendas";
            this.btTotalVendas.Size = new System.Drawing.Size(60, 75);
            this.btTotalVendas.TabIndex = 5;
            this.btTotalVendas.Text = "Total de Vendas";
            this.btTotalVendas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btTotalVendas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btTotalVendas.UseVisualStyleBackColor = false;
            this.btTotalVendas.Click += new System.EventHandler(this.btTotalVendas_Click);
            // 
            // btCargaDevolução
            // 
            this.btCargaDevolução.BackColor = System.Drawing.Color.Transparent;
            this.btCargaDevolução.FlatAppearance.BorderSize = 0;
            this.btCargaDevolução.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCargaDevolução.Image = global::ControleEstoque.Properties.Resources.icons8_trolley_40;
            this.btCargaDevolução.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCargaDevolução.Location = new System.Drawing.Point(196, 107);
            this.btCargaDevolução.Margin = new System.Windows.Forms.Padding(0);
            this.btCargaDevolução.Name = "btCargaDevolução";
            this.btCargaDevolução.Size = new System.Drawing.Size(101, 60);
            this.btCargaDevolução.TabIndex = 8;
            this.btCargaDevolução.Text = "Carga/Devolução";
            this.btCargaDevolução.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCargaDevolução.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btCargaDevolução.UseVisualStyleBackColor = false;
            this.btCargaDevolução.Click += new System.EventHandler(this.btCargaDevolução_Click);
            // 
            // btDepositos
            // 
            this.btDepositos.BackColor = System.Drawing.Color.Transparent;
            this.btDepositos.FlatAppearance.BorderSize = 0;
            this.btDepositos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDepositos.Image = global::ControleEstoque.Properties.Resources.icons8_refund_40;
            this.btDepositos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btDepositos.Location = new System.Drawing.Point(134, 107);
            this.btDepositos.Margin = new System.Windows.Forms.Padding(0);
            this.btDepositos.Name = "btDepositos";
            this.btDepositos.Size = new System.Drawing.Size(62, 60);
            this.btDepositos.TabIndex = 7;
            this.btDepositos.Text = "Depositos";
            this.btDepositos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btDepositos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btDepositos.UseVisualStyleBackColor = false;
            this.btDepositos.Click += new System.EventHandler(this.btDepositos_Click);
            // 
            // txtNomeVendedor
            // 
            this.txtNomeVendedor.Enabled = false;
            this.txtNomeVendedor.Location = new System.Drawing.Point(118, 26);
            this.txtNomeVendedor.Name = "txtNomeVendedor";
            this.txtNomeVendedor.Size = new System.Drawing.Size(445, 20);
            this.txtNomeVendedor.TabIndex = 69;
            // 
            // txtIdVendedor
            // 
            this.txtIdVendedor.Enabled = false;
            this.txtIdVendedor.Location = new System.Drawing.Point(12, 26);
            this.txtIdVendedor.Name = "txtIdVendedor";
            this.txtIdVendedor.Size = new System.Drawing.Size(73, 20);
            this.txtIdVendedor.TabIndex = 68;
            // 
            // btSearchVendedor
            // 
            this.btSearchVendedor.FlatAppearance.BorderSize = 0;
            this.btSearchVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearchVendedor.Image = global::ControleEstoque.Properties.Resources.search_16;
            this.btSearchVendedor.Location = new System.Drawing.Point(90, 25);
            this.btSearchVendedor.Name = "btSearchVendedor";
            this.btSearchVendedor.Size = new System.Drawing.Size(21, 21);
            this.btSearchVendedor.TabIndex = 66;
            this.btSearchVendedor.UseVisualStyleBackColor = true;
            this.btSearchVendedor.Click += new System.EventHandler(this.btSearchVendedor_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Código Vendedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Data Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Data Final";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.Location = new System.Drawing.Point(12, 75);
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(100, 20);
            this.txtDataInicial.TabIndex = 74;
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.Location = new System.Drawing.Point(121, 75);
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(100, 20);
            this.txtDataFinal.TabIndex = 75;
            // 
            // btEstoque
            // 
            this.btEstoque.BackColor = System.Drawing.Color.Transparent;
            this.btEstoque.FlatAppearance.BorderSize = 0;
            this.btEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEstoque.Image = global::ControleEstoque.Properties.Resources.icons8_sell_stock_40;
            this.btEstoque.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEstoque.Location = new System.Drawing.Point(297, 107);
            this.btEstoque.Margin = new System.Windows.Forms.Padding(0);
            this.btEstoque.Name = "btEstoque";
            this.btEstoque.Size = new System.Drawing.Size(65, 60);
            this.btEstoque.TabIndex = 76;
            this.btEstoque.Text = "Estoque";
            this.btEstoque.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEstoque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btEstoque.UseVisualStyleBackColor = false;
            this.btEstoque.Click += new System.EventHandler(this.btEstoque_Click);
            // 
            // cbbPraça
            // 
            this.cbbPraça.FormattingEnabled = true;
            this.cbbPraça.Location = new System.Drawing.Point(569, 25);
            this.cbbPraça.Name = "cbbPraça";
            this.cbbPraça.Size = new System.Drawing.Size(121, 21);
            this.cbbPraça.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Praça";
            // 
            // FrmRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 196);
            this.Controls.Add(this.cbbPraça);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btEstoque);
            this.Controls.Add(this.txtDataFinal);
            this.Controls.Add(this.txtDataInicial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeVendedor);
            this.Controls.Add(this.txtIdVendedor);
            this.Controls.Add(this.btSearchVendedor);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btCargaDevolução);
            this.Controls.Add(this.btDepositos);
            this.Controls.Add(this.btComissões);
            this.Controls.Add(this.btTotalVendas);
            this.Name = "FrmRelatorios";
            this.Text = "Relatórios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTotalVendas;
        private System.Windows.Forms.Button btComissões;
        private System.Windows.Forms.Button btCargaDevolução;
        private System.Windows.Forms.Button btDepositos;
        private System.Windows.Forms.TextBox txtNomeVendedor;
        private System.Windows.Forms.TextBox txtIdVendedor;
        private System.Windows.Forms.Button btSearchVendedor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataInicial;
        private System.Windows.Forms.TextBox txtDataFinal;
        private System.Windows.Forms.Button btEstoque;
        private System.Windows.Forms.ComboBox cbbPraça;
        private System.Windows.Forms.Label label3;
    }
}