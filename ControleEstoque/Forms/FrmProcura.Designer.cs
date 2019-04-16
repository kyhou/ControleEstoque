namespace ControleEstoque
{
    partial class FrmProcura
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
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.cbbColunaPesquisa = new System.Windows.Forms.ComboBox();
            this.cbbQuery = new System.Windows.Forms.ComboBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(12, 55);
            this.dgvResultados.MultiSelect = false;
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.Size = new System.Drawing.Size(776, 256);
            this.dgvResultados.TabIndex = 0;
            // 
            // cbbColunaPesquisa
            // 
            this.cbbColunaPesquisa.FormattingEnabled = true;
            this.cbbColunaPesquisa.Location = new System.Drawing.Point(12, 12);
            this.cbbColunaPesquisa.Name = "cbbColunaPesquisa";
            this.cbbColunaPesquisa.Size = new System.Drawing.Size(121, 21);
            this.cbbColunaPesquisa.TabIndex = 1;
            // 
            // cbbQuery
            // 
            this.cbbQuery.FormattingEnabled = true;
            this.cbbQuery.Items.AddRange(new object[] {
            "Igual a",
            "Começa com",
            "Termina com",
            "Contém"});
            this.cbbQuery.Location = new System.Drawing.Point(139, 12);
            this.cbbQuery.Name = "cbbQuery";
            this.cbbQuery.Size = new System.Drawing.Size(121, 21);
            this.cbbQuery.TabIndex = 2;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(266, 12);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(436, 20);
            this.txtQuery.TabIndex = 3;
            // 
            // btOk
            // 
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.FlatAppearance.BorderSize = 0;
            this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOk.Image = global::ControleEstoque.Properties.Resources.icons8_checkmark_30;
            this.btOk.Location = new System.Drawing.Point(12, 320);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(35, 31);
            this.btOk.TabIndex = 37;
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btPesquisar
            // 
            this.btPesquisar.Image = global::ControleEstoque.Properties.Resources.search_16;
            this.btPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPesquisar.Location = new System.Drawing.Point(708, 7);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(80, 28);
            this.btPesquisar.TabIndex = 4;
            this.btPesquisar.Text = "Pesquisar";
            this.btPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPesquisar.UseVisualStyleBackColor = true;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.FlatAppearance.BorderSize = 0;
            this.btCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancelar.Image = global::ControleEstoque.Properties.Resources.delete_sign;
            this.btCancelar.Location = new System.Drawing.Point(53, 320);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(35, 31);
            this.btCancelar.TabIndex = 38;
            this.btCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmProcura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(800, 363);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btPesquisar);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.cbbQuery);
            this.Controls.Add(this.cbbColunaPesquisa);
            this.Controls.Add(this.dgvResultados);
            this.Name = "FrmProcura";
            this.Text = "Procura";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.ComboBox cbbColunaPesquisa;
        private System.Windows.Forms.ComboBox cbbQuery;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancelar;
    }
}