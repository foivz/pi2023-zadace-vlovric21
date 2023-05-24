namespace HelpDesk
{
    partial class FrmMain
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
            this.dgvPopisZahtjeva = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopisZahtjeva)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPopisZahtjeva
            // 
            this.dgvPopisZahtjeva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPopisZahtjeva.Location = new System.Drawing.Point(131, 27);
            this.dgvPopisZahtjeva.Name = "dgvPopisZahtjeva";
            this.dgvPopisZahtjeva.RowHeadersWidth = 51;
            this.dgvPopisZahtjeva.RowTemplate.Height = 24;
            this.dgvPopisZahtjeva.Size = new System.Drawing.Size(668, 422);
            this.dgvPopisZahtjeva.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPopisZahtjeva);
            this.Name = "frmMain";
            this.Text = "frmMain";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopisZahtjeva)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPopisZahtjeva;
    }
}