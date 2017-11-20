using SQLDatabase.Net.SQLDatabaseClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDatabase.Net.Explorer
{
    public partial class CreateIndexForm : Form
    {
        public CreateIndexForm()
        {
            InitializeComponent();
        }

        public CreateIndexForm(IEnumerable<ISqlDataObject> tables) : this()
        {
            Tables = tables;
        }

        public string IndexName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private BindingList<SqlDataColumn> selectedColumns = new BindingList<SqlDataColumn>();
        private BindingList<SqlDataColumn> aviableColumns = new BindingList<SqlDataColumn>();

        IEnumerable<ISqlDataObject> _tables = null;
        public IEnumerable<ISqlDataObject> Tables
        {
            get { return _tables; }
            set
            {
                cbTable.DataSource = null;
                _tables = value;
                if (_tables == null) return;
                cbTable.DataSource = value;
                cbTable.DisplayMember = "Name";
                try
                {
                    if (_tables.Count() == 1)
                    {
                        cbTable.Enabled = false;
                        IndexName = "IDX_" + _tables.First().Name;
                    }
                    else
                    {
                        cbTable.Enabled = true;
                    }
                }
                catch
                {
                    // NOOP
                }
            }
        }

        public bool Unique
        {
            get
            {
                return cbIsUnique.Checked;
            }
            set
            {
                cbIsUnique.Checked = value;
            }
        }

        private void CreateIndexForm_Load(object sender, EventArgs e)
        {

        }

        private void cbTable_SelectedValueChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            var table = (cbTable.SelectedItem as ISqlDataObject);
            if (table == null) return;
            if (table.Columns.Count == 0)
            {
                using (var con = new SqlDatabaseConnection(table.ConnectionString)) {
                    con.Open();
                    table.GetColumns(con);
                }
            }


            aviableColumns = new BindingList<SqlDataColumn>(table.Columns.ToList());
            listBox1.DataSource = aviableColumns;
            listBox1.DisplayMember = "Name";

            selectedColumns.Clear();
            listBox2.DataSource = selectedColumns;
            listBox2.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null) return;
            var item = listBox1.SelectedItem as SqlDataColumn;
            if (item == null) return;
            aviableColumns.Remove(item);
            selectedColumns.Add(item);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var table = cbTable.SelectedItem as SqlDataTable;
            if (table == null)
            {
                MessageBox.Show("No table selected.", "Information", MessageBoxButtons.OK);
                return;
            }

            var cols = new List<string>();
            foreach (SqlDataColumn col in selectedColumns)
            {
                cols.Add(col.Name);
            }

            if (cols.Count == 0)
            {
                MessageBox.Show("No columns selected.", "Information", MessageBoxButtons.OK);
                return;
            }


            const string Sql = "CREATE {0} INDEX IF NOT EXISTS {1} ON {2} ({3});";
            string sql = string.Format(Sql, (Unique ? "UNIQUE" : ""), IndexName, table.Name, string.Join(",", cols));
            using (var con = new SqlDatabaseConnection(table.ConnectionString))
            {
                try
                {
                    con.Open();
                    using (var cmd = new SqlDatabaseCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

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

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
