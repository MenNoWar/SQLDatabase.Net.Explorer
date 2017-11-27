namespace SQLDatabase.Net.Explorer
{
    partial class DataViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataViewForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCreatePKey = new System.Windows.Forms.ToolStripButton();
            this.tsiRecordInfo = new System.Windows.Forms.ToolStripLabel();
            this.tsbLoadNext = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreatePKey,
            this.tsiRecordInfo,
            this.tsbLoadNext});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(666, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCreatePKey
            // 
            this.btnCreatePKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreatePKey.Image = ((System.Drawing.Image)(resources.GetObject("btnCreatePKey.Image")));
            this.btnCreatePKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreatePKey.Name = "btnCreatePKey";
            this.btnCreatePKey.Size = new System.Drawing.Size(23, 22);
            this.btnCreatePKey.Text = "toolStripButton1";
            this.btnCreatePKey.Click += new System.EventHandler(this.btnCreatePKey_Click);
            // 
            // tsiRecordInfo
            // 
            this.tsiRecordInfo.Name = "tsiRecordInfo";
            this.tsiRecordInfo.Size = new System.Drawing.Size(86, 22);
            this.tsiRecordInfo.Text = "toolStripLabel1";
            // 
            // tsbLoadNext
            // 
            this.tsbLoadNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLoadNext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbLoadNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadNext.Image")));
            this.tsbLoadNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadNext.Name = "tsbLoadNext";
            this.tsbLoadNext.Size = new System.Drawing.Size(112, 22);
            this.tsbLoadNext.Text = "Load next x records";
            this.tsbLoadNext.Click += new System.EventHandler(this.tsbLoadNext_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(666, 269);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridView1_RowEnter);
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridView1_RowValidated);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this._dataGridView1_UserDeletingRow);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // DataViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 298);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DataViewForm";
            this.Text = "DataViewForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataViewForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCreatePKey;
        private System.Windows.Forms.ToolStripLabel tsiRecordInfo;
        private System.Windows.Forms.ToolStripButton tsbLoadNext;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}