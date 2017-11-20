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
    public partial class ChooseKeyColumnsForm : Form
    {
        public ChooseKeyColumnsForm()
        {
            InitializeComponent();
        }

        public ChooseKeyColumnsForm(ISqlDataObject table) : this()
        {
            Table = table;
        }

        private ISqlDataObject _table = new SqlDataTable();
        public ISqlDataObject Table
        {
            get
            {
                return _table;
            }

            set
            {
                _table = value;
                UpdateColumnList();
            }
        }

        private void UpdateColumnList()
        {
            cbColumns.Items.Clear();
            if (Table == null || Table.Columns == null) return;
            foreach (var col in Table.Columns)
            {
                var colIdx = cbColumns.Items.Add(col);
                cbColumns.SetItemChecked(colIdx, col.Name.EndsWith("Id"));
            }
        }

        private void ChooseKeyColumnsForm_Load(object sender, EventArgs e)
        {

        }

        private DataTable BackupData = new DataTable("UNNAMED");
        
        private void button1_Click(object sender, EventArgs e)
        {
            BackupData = new DataTable(Table.Name);

            for (var i = 0; i < cbColumns.Items.Count; i++)
            {
                var col = this.Table.Columns.First(o => o == cbColumns.Items[i]);
                col.IsPKey = cbColumns.GetItemChecked(i);
            }

            using (var con = new SqlDatabaseConnection(Table.ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlDatabaseCommand("SELECT * FROM " + Table.Name, con))
                {
                    using (var da = new SqlDatabaseDataAdapter(cmd))
                    {
                        da.Fill(BackupData);
                    }
                }

                var transaction = con.BeginTransaction();
                try
                {
                    using (var cmd = new SqlDatabaseCommand("DROP TABLE " + Table.Name, con))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    Utils.CreateTableFromDefinition(Table, con);
                    Utils.RestoreTableFromBackup(BackupData, con, transaction);

                    transaction.Commit();

                    this.DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void cbColumns_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            cbColumns.ItemCheck -= cbColumns_ItemCheck;
            for (var i = 0; i < cbColumns.Items.Count; i++)
            {
                cbColumns.SetItemChecked(i, false);
            }

            cbColumns.SetItemChecked(e.Index, true);
            cbColumns.ItemCheck += cbColumns_ItemCheck;
        }
    }
}
