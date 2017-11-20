namespace SQLDatabase.Net.Explorer
{
    partial class ColumnDisplay
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnDisplay));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDataType = new System.Windows.Forms.ComboBox();
            this.cbPrimaryKey = new System.Windows.Forms.CheckBox();
            this.cbNullable = new System.Windows.Forms.CheckBox();
            this.tbDefaultValue = new System.Windows.Forms.TextBox();
            this.tbColumnName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbAutoInc = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbAutoInc);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbDataType);
            this.panel1.Controls.Add(this.cbPrimaryKey);
            this.panel1.Controls.Add(this.cbNullable);
            this.panel1.Controls.Add(this.tbDefaultValue);
            this.panel1.Controls.Add(this.tbColumnName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 53);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DataType";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Default Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Col.-Name";
            // 
            // cbDataType
            // 
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Items.AddRange(new object[] {
            "Blob",
            "Integer",
            "None",
            "Real",
            "Text"});
            this.cbDataType.Location = new System.Drawing.Point(420, 25);
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(164, 21);
            this.cbDataType.Sorted = true;
            this.cbDataType.TabIndex = 4;
            // 
            // cbPrimaryKey
            // 
            this.cbPrimaryKey.AutoSize = true;
            this.cbPrimaryKey.Location = new System.Drawing.Point(125, 27);
            this.cbPrimaryKey.Name = "cbPrimaryKey";
            this.cbPrimaryKey.Size = new System.Drawing.Size(81, 17);
            this.cbPrimaryKey.TabIndex = 3;
            this.cbPrimaryKey.Text = "Primary Key";
            this.cbPrimaryKey.UseVisualStyleBackColor = true;
            this.cbPrimaryKey.CheckedChanged += new System.EventHandler(this.cbPrimaryKey_CheckedChanged);
            this.cbPrimaryKey.Click += new System.EventHandler(this.cbPrimaryKey_Click);
            // 
            // cbNullable
            // 
            this.cbNullable.AutoSize = true;
            this.cbNullable.Checked = true;
            this.cbNullable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNullable.Location = new System.Drawing.Point(125, 4);
            this.cbNullable.Name = "cbNullable";
            this.cbNullable.Size = new System.Drawing.Size(64, 17);
            this.cbNullable.TabIndex = 2;
            this.cbNullable.Text = "Nullable";
            this.cbNullable.UseVisualStyleBackColor = true;
            // 
            // tbDefaultValue
            // 
            this.tbDefaultValue.Location = new System.Drawing.Point(305, 26);
            this.tbDefaultValue.Name = "tbDefaultValue";
            this.tbDefaultValue.Size = new System.Drawing.Size(109, 20);
            this.tbDefaultValue.TabIndex = 1;
            // 
            // tbColumnName
            // 
            this.tbColumnName.Location = new System.Drawing.Point(3, 26);
            this.tbColumnName.Name = "tbColumnName";
            this.tbColumnName.Size = new System.Drawing.Size(115, 20);
            this.tbColumnName.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // cbAutoInc
            // 
            this.cbAutoInc.AutoSize = true;
            this.cbAutoInc.Enabled = false;
            this.cbAutoInc.Location = new System.Drawing.Point(212, 26);
            this.cbAutoInc.Name = "cbAutoInc";
            this.cbAutoInc.Size = new System.Drawing.Size(62, 17);
            this.cbAutoInc.TabIndex = 9;
            this.cbAutoInc.Text = "Autoinc";
            this.cbAutoInc.UseVisualStyleBackColor = true;
            this.cbAutoInc.Click += new System.EventHandler(this.cbAutoInc_Click);
            // 
            // ColumnDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ColumnDisplay";
            this.Size = new System.Drawing.Size(589, 53);
            this.Leave += new System.EventHandler(this.ColumnDisplay_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbPrimaryKey;
        private System.Windows.Forms.CheckBox cbNullable;
        private System.Windows.Forms.TextBox tbDefaultValue;
        private System.Windows.Forms.TextBox tbColumnName;
        private System.Windows.Forms.ComboBox cbDataType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbAutoInc;
    }
}
