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
    public partial class DataViewForm : Form
    {
        public DataViewForm()
        {
            InitializeComponent();
        }

        private DataTable table = null;
        private SqlDatabaseDataAdapter adapter = null;
        private SqlDatabaseCommand command = null;
        private SqlDatabaseConnection connection = null;
        private bool hasPrimaryKey = false;
        private ISqlDataObject sourceTable = null;
        private int start = 0;
        private int pageSize = 25;
        private int total = 0;
        private Dictionary<string, object> oldValues = new Dictionary<string, object>();

        private void UpdateRecordsInfo()
        {
            if (pageSize >= total || start >= total)
            {
                pageSize = total;
                tsbLoadNext.Visible = false;
            }

            var curCount = table.Rows.Count;
            tsiRecordInfo.Text = string.Format("Records 1-{0}/{1}", curCount, total);
            var p2 = curCount + pageSize > total ? total - curCount : pageSize;
            tsbLoadNext.Text = string.Format("Load next {0} records", p2);
        }

        private void ReadNextPage()
        {
            start += pageSize;
            var sql = "SELECT * FROM " + table.TableName + " LIMIT " + pageSize + " OFFSET " + start;
            adapter.SelectCommand = new SqlDatabaseCommand(sql, connection);
            adapter.Fill(this.table);
            UpdateRecordsInfo();
        }

        public void InitializeData(ISqlDataObject table)
        {            
            var sql = "SELECT * FROM " + table.Name + " LIMIT " + pageSize + " OFFSET " + start;
            var sqlCount = "SELECT COUNT(*) FROM " + table.Name;

            this.Text = table.Name;

            connection = new SqlDatabaseConnection(table.ConnectionString);
            connection.Open();
            this.table = new DataTable(table.Name);
            command = new SqlDatabaseCommand(sql, connection);
            adapter = new SqlDatabaseDataAdapter(command);
            adapter.Fill(this.table);
            total = Convert.ToInt32(new SqlDatabaseCommand(sqlCount, connection).ExecuteScalar());

            sourceTable = table;
            hasPrimaryKey = table.Columns.Any(o => o.IsPKey);

            btnCreatePKey.Enabled = !hasPrimaryKey;
            btnCreatePKey.ToolTipText = hasPrimaryKey ? "Table has existent primary key" : "Recreate Table with primary Key";
            btnCreatePKey.Visible = !hasPrimaryKey;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.DataSource = this.table;

            if (table.GetType() == typeof(SqlDataView))
            {
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
            }

            UpdateRecordsInfo();
        }
        

        private DataRow RowFromIndex(int rowIndex)
        {
            DataGridViewRow gridrow = dataGridView1.Rows[rowIndex];
            if (gridrow == null) return null;
            DataRowView rowview = (DataRowView)gridrow.DataBoundItem;
            if (rowview == null) return null;
            DataRow row = rowview.Row;

            return row;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var sqlDelete = "DELETE FROM " + table.TableName + " WHERE\n";
            var cols = new List<string>();
            using (var deleteCmd = new SqlDatabaseCommand(connection))
            {
                foreach (DataColumn c in table.Columns)
                {
                    var val = e.Row.Cells[c.ColumnName].Value;
                    if (val != DBNull.Value)
                    {
                        cols.Add(string.Format("{0} = @{0}\n", c.ColumnName));
                        deleteCmd.Parameters.Add("@" + c.ColumnName, val);
                    } else
                    {
                        cols.Add(string.Format("{0} is null\n", c.ColumnName));
                    }
                }

                sqlDelete += string.Join("AND ", cols);

                deleteCmd.CommandText = sqlDelete;

                deleteCmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataRow row = RowFromIndex(e.RowIndex);
            // var id = (string)row["Id"];
            if (row == null) return;
            if (row.RowState != DataRowState.Unchanged)
            {
                switch (row.RowState)
                {
                    case DataRowState.Added:
                        var insertCommand = new SqlDatabaseCommand(connection);
                        var insertSql = "INSERT INTO " + row.Table.TableName + "(\n";
                        var insertFields = new List<string>();
                        var insertParamNames = new List<string>();
                        foreach (DataColumn col in row.Table.Columns)
                        {
                            var paramName = string.Format("@{0}", col.ColumnName);
                            insertCommand.Parameters.Add(paramName, row[col.ColumnName]);                            
                            insertParamNames.Add(paramName);
                            insertFields.Add(string.Format("{0}\n", col.ColumnName));
                        }

                        insertSql += string.Join(",", insertFields);
                        insertSql += ")\nVALUES\n(";
                        insertSql += string.Join(",", insertParamNames);
                        insertSql += ")";

                        insertCommand.CommandText = insertSql;
                        insertCommand.ExecuteNonQuery();
                        break;

                    case DataRowState.Deleted:
                        break;
                    case DataRowState.Modified:
                        var updateCommand = new SqlDatabaseCommand(connection);                        
                        var updateFields = new List<string>();
                        var oldFields = new List<string>();
                        string updateSql;

                        foreach (DataColumn col in row.Table.Columns)
                        {
                            updateCommand.Parameters.Add("@" + col.ColumnName, row[col.ColumnName]);
                            updateFields.Add(string.Format("{0} = @{0}\n", col.ColumnName));
                        }
                        
                        foreach (var kvp in oldValues)
                        {
                            oldFields.Add(string.Format("{0} = @old_{0}\n", kvp.Key));
                            updateCommand.Parameters.Add("@old_" + kvp.Key, kvp.Value);
                        }

                        updateSql = "UPDATE " + row.Table.TableName + " SET \n";
                        updateSql += string.Join(",", updateFields);
                        updateSql += "WHERE\n";
                        updateSql += string.Join(" AND ", oldFields);

                        updateCommand.CommandText = updateSql;
                        updateCommand.ExecuteNonQuery();
                        break;
                }

                ((DataTable)dataGridView1.DataSource).AcceptChanges();
            }
        }
        
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            oldValues.Clear();
            var row = RowFromIndex(e.RowIndex);
            if (row != null)
            {                
                foreach (DataColumn col in row.Table.Columns)
                {
                    oldValues.Add(col.ColumnName, row[col.ColumnName]);
                }
            }
        }

        private void btnCreatePKey_Click(object sender, EventArgs e)
        {
            if (hasPrimaryKey) return;
            var sql = string.Format("CREATE UNIQUE INDEX  PKPatientDetails ON {0} (PatientId)", sourceTable.Name);
            var frm = new ChooseKeyColumnsForm(sourceTable) { Text = "Choose Columns for Primary Key" };
            frm.ShowDialog();
        }

        private void tsbLoadNext_Click(object sender, EventArgs e)
        {
            ReadNextPage();
        }

        private void DataViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
            table.Dispose();
        }
    }
}
