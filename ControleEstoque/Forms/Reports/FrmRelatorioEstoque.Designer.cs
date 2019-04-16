namespace ControleEstoque
{
    partial class FrmRelatorioEstoque
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
            this.rvEstoque = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvEstoque
            // 
            this.rvEstoque.LocalReport.ReportEmbeddedResource = "ControleEstoque.Reports.RpEstoque.rdlc";
            this.rvEstoque.Location = new System.Drawing.Point(0, 0);
            this.rvEstoque.Name = "rvEstoque";
            this.rvEstoque.ServerReport.BearerToken = null;
            this.rvEstoque.Size = new System.Drawing.Size(800, 451);
            this.rvEstoque.TabIndex = 0;
            // 
            // FrmRelatorioEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rvEstoque);
            this.Name = "FrmRelatorioEstoque";
            this.Text = "FrmRelatorioEstoque";
            this.Load += new System.EventHandler(this.FrmRelatorioEstoque_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvEstoque;
    }
}