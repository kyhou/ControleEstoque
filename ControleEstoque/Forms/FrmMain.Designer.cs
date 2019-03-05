namespace ControleEstoque
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btFrmPedidos = new System.Windows.Forms.Button();
            this.btFrmProdutos = new System.Windows.Forms.Button();
            this.btFrmVendedores = new System.Windows.Forms.Button();
            this.btFrmPraças = new System.Windows.Forms.Button();
            this.btFrmPessoas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btFrmPedidos
            // 
            this.btFrmPedidos.BackColor = System.Drawing.Color.Transparent;
            this.btFrmPedidos.FlatAppearance.BorderSize = 0;
            this.btFrmPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFrmPedidos.Image = global::ControleEstoque.Properties.Resources.icons8_push_cart_40;
            this.btFrmPedidos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btFrmPedidos.Location = new System.Drawing.Point(300, 9);
            this.btFrmPedidos.Margin = new System.Windows.Forms.Padding(0);
            this.btFrmPedidos.Name = "btFrmPedidos";
            this.btFrmPedidos.Size = new System.Drawing.Size(60, 60);
            this.btFrmPedidos.TabIndex = 4;
            this.btFrmPedidos.Text = "Pedidos";
            this.btFrmPedidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btFrmPedidos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btFrmPedidos.UseVisualStyleBackColor = false;
            this.btFrmPedidos.Click += new System.EventHandler(this.BtFrmPedidos_Click);
            // 
            // btFrmProdutos
            // 
            this.btFrmProdutos.BackColor = System.Drawing.Color.Transparent;
            this.btFrmProdutos.FlatAppearance.BorderSize = 0;
            this.btFrmProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFrmProdutos.Image = global::ControleEstoque.Properties.Resources.icons8_new_product_40;
            this.btFrmProdutos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btFrmProdutos.Location = new System.Drawing.Point(231, 9);
            this.btFrmProdutos.Margin = new System.Windows.Forms.Padding(0);
            this.btFrmProdutos.Name = "btFrmProdutos";
            this.btFrmProdutos.Size = new System.Drawing.Size(60, 60);
            this.btFrmProdutos.TabIndex = 3;
            this.btFrmProdutos.Text = "Produtos";
            this.btFrmProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btFrmProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btFrmProdutos.UseVisualStyleBackColor = false;
            this.btFrmProdutos.Click += new System.EventHandler(this.BtFrmProdutos_Click);
            // 
            // btFrmVendedores
            // 
            this.btFrmVendedores.BackColor = System.Drawing.Color.Transparent;
            this.btFrmVendedores.FlatAppearance.BorderSize = 0;
            this.btFrmVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFrmVendedores.Image = global::ControleEstoque.Properties.Resources.icons8_businessman_40;
            this.btFrmVendedores.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btFrmVendedores.Location = new System.Drawing.Point(147, 9);
            this.btFrmVendedores.Margin = new System.Windows.Forms.Padding(0);
            this.btFrmVendedores.Name = "btFrmVendedores";
            this.btFrmVendedores.Size = new System.Drawing.Size(75, 60);
            this.btFrmVendedores.TabIndex = 2;
            this.btFrmVendedores.Text = "Vendedores";
            this.btFrmVendedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btFrmVendedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btFrmVendedores.UseVisualStyleBackColor = false;
            this.btFrmVendedores.Click += new System.EventHandler(this.BtFrmVendedores_Click);
            // 
            // btFrmPraças
            // 
            this.btFrmPraças.BackColor = System.Drawing.Color.Transparent;
            this.btFrmPraças.FlatAppearance.BorderSize = 0;
            this.btFrmPraças.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFrmPraças.Image = global::ControleEstoque.Properties.Resources.icons8_marker_40;
            this.btFrmPraças.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btFrmPraças.Location = new System.Drawing.Point(78, 9);
            this.btFrmPraças.Margin = new System.Windows.Forms.Padding(0);
            this.btFrmPraças.Name = "btFrmPraças";
            this.btFrmPraças.Size = new System.Drawing.Size(60, 60);
            this.btFrmPraças.TabIndex = 1;
            this.btFrmPraças.Text = "Praças";
            this.btFrmPraças.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btFrmPraças.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btFrmPraças.UseVisualStyleBackColor = false;
            this.btFrmPraças.Click += new System.EventHandler(this.BtFrmPraças_Click);
            // 
            // btFrmPessoas
            // 
            this.btFrmPessoas.BackColor = System.Drawing.Color.Transparent;
            this.btFrmPessoas.FlatAppearance.BorderSize = 0;
            this.btFrmPessoas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFrmPessoas.Image = global::ControleEstoque.Properties.Resources.icons8_grupos_de_usuários_40;
            this.btFrmPessoas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btFrmPessoas.Location = new System.Drawing.Point(9, 9);
            this.btFrmPessoas.Margin = new System.Windows.Forms.Padding(0);
            this.btFrmPessoas.Name = "btFrmPessoas";
            this.btFrmPessoas.Size = new System.Drawing.Size(60, 60);
            this.btFrmPessoas.TabIndex = 0;
            this.btFrmPessoas.Text = "Pessoas";
            this.btFrmPessoas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btFrmPessoas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btFrmPessoas.UseVisualStyleBackColor = false;
            this.btFrmPessoas.Click += new System.EventHandler(this.BtFrmPessoas_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btFrmPedidos);
            this.Controls.Add(this.btFrmProdutos);
            this.Controls.Add(this.btFrmVendedores);
            this.Controls.Add(this.btFrmPraças);
            this.Controls.Add(this.btFrmPessoas);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btFrmPessoas;
        private System.Windows.Forms.Button btFrmPraças;
        private System.Windows.Forms.Button btFrmVendedores;
        private System.Windows.Forms.Button btFrmProdutos;
        private System.Windows.Forms.Button btFrmPedidos;
    }
}

