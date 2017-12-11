using SQLDatabase.Net.SQLDatabaseClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLDatabase.Net.Explorer
{
    public class DbSettingItem
    {
        public TreeNode TnIndizes { get; set; }
        public TreeNode TnViews { get; set; }
        public TreeNode TnTables { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string ConnectionString
        {
            get
            {
                var s = string.Format("Schema={0};DataSource=file://{1}", Schema, DbFile); ;
                if (!string.IsNullOrEmpty(Key))
                {
                  //  s += string.Format(";key={0}", Key);
                }

                return s;
            }
        }

        public SqlDatabaseConnection GetConnection()
        {            
            var con = new SqlDatabaseConnection(ConnectionString);
            return con;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string DbFile { get; set; }
        public string Key { get; set; }
        public string Schema { get; set; }        

        public List<ISqlDataObject> Tables { get; set; }
        public List<ISqlDataObject> Views { get; set; }

        public List<ISqlDataObject> Indizes { get; set; }

        private List<ISqlDataObject> GetObjects(string type)
        {
            var tableList = new List<ISqlDataObject>();
            string sql = string.Format("SELECT * FROM SYS_OBJECTS WHERE type = '{0}';", type);

            using (SqlDatabaseConnection con = new SqlDatabaseConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                }
                catch
                {
                    return tableList;
                }

                using (var cmd = new SqlDatabaseCommand(sql, con))
                {
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (type == "table")
                        {
                            var table = new SqlDataTable
                            {
                                TableName = rdr.GetString(3),
                                Name = rdr.GetString(2),
                                ConnectionString = con.ConnectionString
                            };

                            if (table.Name != "sys_sequences") tableList.Add(table);
                        }
                        else if (type == "view")
                        {
                            var view = new SqlDataView
                            {
                                TableName = rdr.GetString(3),
                                Name = rdr.GetString(2),
                                ConnectionString = con.ConnectionString
                            };

                            view.GetColumns(con);
                            tableList.Add(view);
                        } else if (type == "index")
                        {
                            var index = new SqlDataIndex
                            {
                                TableName = rdr.GetString(3),
                                Name = rdr.GetString(2),
                                ConnectionString = con.ConnectionString
                            };

                            index.GetColumns(con);
                            tableList.Add(index);
                        }
                    }
                }
            }

            return tableList;
        }
        
        public void ReadObjects()
        {
            Tables = GetObjects("table").ToList(); ;
            Views = GetObjects("view").ToList();
            Indizes = GetObjects("index").ToList();
        }        

        public DbSettingItem()
        {
            Id = Guid.NewGuid().ToString();
        }

        public static void Delete(SqlDatabaseConnection connection, DbSettingItem item)
        {
            const string sql = "DELETE FROM CONNECTIONS WHERE Id=@Id";
            using (var cmd = new SqlDatabaseCommand(sql, connection))
            {
                cmd.Parameters.Add("@Id", item.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Insert(SqlDatabaseConnection connection, DbSettingItem item)
        {
            const string sql = "INSERT INTO CONNECTIONS(Id, Name, DbFile, Key, Schema)\n" +
                    "VALUES \n" +
                    "(@Id, @Name, @DbFile, @Key, @Schema)";
            using (var cmd = new SqlDatabaseCommand(sql, connection))
            {
                cmd.Parameters.Add("@Id", item.Id);
                cmd.Parameters.Add("@Name", item.Name);
                cmd.Parameters.Add("@DbFile", item.DbFile);
                cmd.Parameters.Add("@Key", item.Key);
                cmd.Parameters.Add("@Schema", item.Schema);

                cmd.ExecuteNonQuery();
            }
        }

        private static DbSettingItem FromRow(DataRow row)
        {
            var result = new DbSettingItem
            {
                Id = Convert.ToString(row["Id"]),
                Key = Convert.ToString(row["Key"]),
                DbFile = Convert.ToString(row["DbFile"]),
                Name = Convert.ToString(row["Name"]),
                Schema = Convert.ToString(row["Schema"]),
            };

            return result;
        }

        public static void Update(SqlDatabaseConnection connection, DbSettingItem item)
        {
            const string sql = "UPDATE CONNECTIONS SET \n" +
                    "Name=@Name, DbFile=@DbFile, Key=@Key, Schema=@Schema)\n" +
                    "Where Id=@Id";

            using (var cmd = new SqlDatabaseCommand(sql, connection))
            {
                cmd.Parameters.Add("@Id", item.Id);
                cmd.Parameters.Add("@Name", item.Name);
                cmd.Parameters.Add("@DbFile", item.DbFile);
                cmd.Parameters.Add("@Key", item.Key);
                cmd.Parameters.Add("@Schema", item.Schema);

                cmd.ExecuteNonQuery();
            }
        }

        public static DbSettingItem Read(SqlDatabaseConnection connection, string id)
        {
            const string sql = "SELECT * FROM CONNECTIONS WHERE Id=@Id";
            DataTable dt = new DataTable("Connection");
            using (var cmd = new SqlDatabaseCommand(sql, connection))
            {
                cmd.Parameters.Add("@Id", id);
                using (SqlDatabaseDataAdapter da = new SqlDatabaseDataAdapter(cmd))
                {
                    da.Fill(dt);

                    if (dt.Rows.Count == 0) return null;
                    return FromRow(dt.Rows[0]);
                }
            }
        }

        public static List<DbSettingItem> List(SqlDatabaseConnection connection)
        {
            const string sql = "SELECT * FROM CONNECTIONS ORDER BY NAME";
            DataTable dt = new DataTable("Connections");
            var result = new List<DbSettingItem>();

            using (SqlDatabaseCommand cmd = new SqlDatabaseCommand(sql, connection))
            {
                using (SqlDatabaseDataAdapter da = new SqlDatabaseDataAdapter(cmd))
                {
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        result.Add(FromRow(row));
                    }
                }
            }

            return result;
        }
    }
}
