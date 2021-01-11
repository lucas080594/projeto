namespace EBRAXADMIN
{
    partial class RelatorioConfidentialGerado
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
            this.repConfidential = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // repConfidential
            // 
            this.repConfidential.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repConfidential.LocalReport.ReportEmbeddedResource = "EBRAXADMIN.Confidencial.rdlc";
            this.repConfidential.Location = new System.Drawing.Point(0, 0);
            this.repConfidential.Name = "repConfidential";
            this.repConfidential.ServerReport.BearerToken = null;
            this.repConfidential.Size = new System.Drawing.Size(1189, 549);
            this.repConfidential.TabIndex = 0;
            // 
            // RelatorioConfidentialGerado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 549);
            this.Controls.Add(this.repConfidential);
            this.Name = "RelatorioConfidentialGerado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RelatorioConfidentialGerado";
            this.Load += new System.EventHandler(this.RelatorioConfidentialGerado_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer repConfidential;
    }
}