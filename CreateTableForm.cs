using SQLDatabase.Net.SQLDatabaseClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDatabase.Net.Explorer
{
    public partial class CreateTableForm : Form
    {
        public string TableName
        {
            get { return tbTableName.Text; }
            set
            {
                tbTableName.Text = value;
                Table.Name = tbTableName.Text;
            }
        }
        
        public CreateTableForm()
        {
            InitializeComponent();
            Table = new SqlDataTable();

            Table.Columns.Add(new SqlDataColumn { Name = "Id", IsPKey = true, DefaultValue = null, Nullable = false, Type = "Integer" });
            UpdateColumnDisplay();
        }

        public string ConnectionString { get; set; }

        public SqlDataTable Table { get; set; }
        
        private void UpdateColumnDisplay()
        {
            pnColumnsParent.Controls.Clear();
            var idx = 0;
            foreach (var col in Table.Columns)
            {
                var item = new ColumnDisplay(col);
                pnColumnsParent.Controls.Add(item);
                item.Top = idx * 55;
                item.OnPrimaryKeyChecked += Item_OnPrimaryKeyChecked;

                idx++;
            }
        }

        private void Item_OnPrimaryKeyChecked(object sender)
        {
            var cd = sender as ColumnDisplay;
            
            foreach (ColumnDisplay display in pnColumnsParent.Controls)
            {
                if (sender != display)
                {
                    display.IsPKey = false;
                    display.Column.IsPKey = false;
                    display.Column.AutoInc = false;
                    display.AutoInc = false;
                    display.IsNullable = true;
                    display.Column.Nullable = true;
                } else
                {
                    display.IsPKey = true;
                    display.Column.IsPKey = true;
                }
            }
        }

        private void CreateTableForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            Table.Columns.Add(new SqlDataColumn { 
                Type = "None",
                IsPKey = false,
                Nullable = true,
                DefaultValue = string.Empty
            });

            UpdateColumnDisplay();
        }

        

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbTableName.Text))
            {
                MessageBox.Show("No name for the new table entered.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Table.Name = tbTableName.Text;
            Table.TableName = Table.Name;

            if (!Utils.IsValidName(Table.TableName))
            {
                MessageBox.Show("Tablename '" + Table.TableName + "' is not valid", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (var col in Table.Columns)
            {
                if (string.IsNullOrEmpty(col.Name))
                {
                    MessageBox.Show("At least one column has no name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!Utils.IsValidName(col.Name))
                { 
                    MessageBox.Show("Invalid column name '" + col.Name + "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            
            using (var con = new SqlDatabaseConnection(ConnectionString))
            {
                con.Open();
                try
                {
                    Utils.CreateTableFromDefinition(Table, con);
                    this.DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
                finally
                {
                    con.Close();
                }
            }            
        }
    }
}