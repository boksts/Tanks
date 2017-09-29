namespace WinFormsClient {
    partial class GameJournal {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dgvGameJournal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGameJournal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGameJournal
            // 
            this.dgvGameJournal.AllowUserToAddRows = false;
            this.dgvGameJournal.AllowUserToDeleteRows = false;
            this.dgvGameJournal.AllowUserToResizeColumns = false;
            this.dgvGameJournal.AllowUserToResizeRows = false;
            this.dgvGameJournal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGameJournal.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvGameJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGameJournal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGameJournal.Location = new System.Drawing.Point(0, 0);
            this.dgvGameJournal.MultiSelect = false;
            this.dgvGameJournal.Name = "dgvGameJournal";
            this.dgvGameJournal.ReadOnly = true;
            this.dgvGameJournal.RowHeadersVisible = false;
            this.dgvGameJournal.RowTemplate.Height = 24;
            this.dgvGameJournal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvGameJournal.Size = new System.Drawing.Size(677, 253);
            this.dgvGameJournal.TabIndex = 0;
            // 
            // GameJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 253);
            this.Controls.Add(this.dgvGameJournal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameJournal";
            this.Text = "GameJournal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGameJournal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGameJournal;
    }
}