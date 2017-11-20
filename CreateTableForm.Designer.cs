namespace SQLDatabase.Net.Explorer
{
    partial class CreateTableForm
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
            SQLDatabase.Net.Explorer.SqlDataColumn sqlDataColumn1 = new SQLDatabase.Net.Explorer.SqlDataColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.btnAddColumn = new System.Windows.Forms.Button();
            this.pnColumnsParent = new System.Windows.Forms.Panel();
            this.columnDisplay1 = new SQLDatabase.Net.Explorer.ColumnDisplay();
            this.btnGenerateTable = new System.Windows.Forms.Button();
            this.pnColumnsParent.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table name";
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(13, 30);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(242, 20);
            this.tbTableName.TabIndex = 1;
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.Location = new System.Drawing.Point(13, 69);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(75, 23);
            this.btnAddColumn.TabIndex = 4;
            this.btnAddColumn.Text = "Add Column";
            this.btnAddColumn.UseVisualStyleBackColor = true;
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            // 
            // pnColumnsParent
            // 
            this.pnColumnsParent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnColumnsParent.AutoScroll = true;
            this.pnColumnsParent.Controls.Add(this.columnDisplay1);
            this.pnColumnsParent.Location = new System.Drawing.Point(13, 98);
            this.pnColumnsParent.Name = "pnColumnsParent";
            this.pnColumnsParent.Size = new System.Drawing.Size(615, 175);
            this.pnColumnsParent.TabIndex = 5;
            // 
            // columnDisplay1
            // 
            this.columnDisplay1.AutoInc = false;
            sqlDataColumn1.AutoInc = false;
            sqlDataColumn1.DefaultValue = "";
            sqlDataColumn1.IsPKey = false;
            sqlDataColumn1.Name = "";
            sqlDataColumn1.Nullable = true;
            sqlDataColumn1.Type = "";
            this.columnDisplay1.Column = sqlDataColumn1;
            this.columnDisplay1.ColumnName = "";
            this.columnDisplay1.DataType = "";
            this.columnDisplay1.DefaultValue = "";
            this.columnDisplay1.IsNullable = true;
            this.columnDisplay1.IsPKey = false;
            this.columnDisplay1.Location = new System.Drawing.Point(3, 3);
            this.columnDisplay1.Name = "columnDisplay1";
            this.columnDisplay1.Size = new System.Drawing.Size(589, 53);
            this.columnDisplay1.TabIndex = 0;
            // 
            // btnGenerateTable
            // 
            this.btnGenerateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateTable.Location = new System.Drawing.Point(512, 282);
            this.btnGenerateTable.Name = "btnGenerateTable";
            this.btnGenerateTable.Size = new System.Drawing.Size(116, 35);
            this.btnGenerateTable.TabIndex = 6;
            this.btnGenerateTable.Text = "Generate table";
            this.btnGenerateTable.UseVisualStyleBackColor = true;
            this.btnGenerateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // CreateTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 326);
            this.Controls.Add(this.btnGenerateTable);
            this.Controls.Add(this.pnColumnsParent);
            this.Controls.Add(this.btnAddColumn);
            this.Controls.Add(this.tbTableName);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(656, 39);
            this.Name = "CreateTableForm";
            this.Text = "Create new Table";
            this.Load += new System.EventHandler(this.CreateTableForm_Load);
            this.pnColumnsParent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Button btnAddColumn;
        private System.Windows.Forms.Panel pnColumnsParent;
        private ColumnDisplay columnDisplay1;
        private System.Windows.Forms.Button btnGenerateTable;
    }
}