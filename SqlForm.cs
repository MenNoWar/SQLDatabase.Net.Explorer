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
    public partial class SqlForm : Form
    {
        private List<DbSettingItem> _connections = new List<DbSettingItem>();
        public List<DbSettingItem> Connections
        {
            get { return _connections; }
            set
            {
                _connections = value;
                foreach (var item in _connections)
                {                    
                    cbConnections.Items.Add(item);
                }

                if (cbConnections.Items.Count > 0)
                {
                    cbConnections.SelectedIndex = 0;
                }
            }
        }

        private DbSettingItem _selectedConnection = null;
        public DbSettingItem SelectedConnection
        {
            get {
                return _selectedConnection;
            }

            set
            {
                _selectedConnection = value;
                cbConnections.SelectedIndex = -1;
                if (_selectedConnection == null) return;

                foreach (DbSettingItem item in cbConnections.Items)
                {
                    if (item.ConnectionString == _selectedConnection.ConnectionString)
                    {
                        cbConnections.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        public SqlForm()
        {
            InitializeComponent();
        }

        public string Sql
        {
            get
            {
                return tbSql.Text.Trim();
            }
            set
            {
                tbSql.Text = value;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (cbConnections.SelectedItem == null) return;
            var conItem = cbConnections.SelectedItem as DbSettingItem;
            var sql = Sql;
            if (string.IsNullOrEmpty(sql)) return;

            using (var con = conItem.GetConnection())
            {
                con.Open();
                var cmd = new SqlDatabaseCommand(sql, con);
                try
                {
                    if (sql.ToUpper().StartsWith("SELECT "))
                    {
                        dgvResult.Visible = true;
                        lblResult.Visible = false;
                        var dt = new DataTable("Result");
                        using (var da = new SqlDatabaseDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }

                        dgvResult.DataSource = dt;
                    }
                    else
                    {
                        dgvResult.Visible = false;
                        lblResult.Visible = true;

                        var i = cmd.ExecuteNonQuery();
                        lblResult.Text = string.Format("{0} Rows affected", i);
                    }
                }
                catch(Exception ex)
                {
                    dgvResult.Visible = false;
                    lblResult.Visible = true;
                    lblResult.Text = ex.Message + "\n\nQuery:\n" + sql;
                }
            }

        }

        private void tbSql_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                toolStripButton1.PerformClick();
            }
        }
    }
}
