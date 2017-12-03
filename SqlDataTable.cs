namespace SQLDatabase.Net.Explorer
{
    using SQLDatabase.Net.SQLDatabaseClient;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class SqlDataView : ISqlDataObject
    {
        public List<SqlDataColumn> Columns { get; set; }
        public string ConnectionString { get; set; }
        public string Name { get; set; }

        public string TableName { get; set; }

        public void GetColumns(SqlDatabaseConnection con)
        {
            var sql = "SYSCMD table_info('" + Name + "')";
            using (var cmd = new SqlDatabaseCommand(sql, con))
            {
                using (var dt = new DataTable("Schema"))
                {
                    using (var da = new SqlDatabaseDataAdapter(cmd))
                    {
                        try
                        {
                            da.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                var col = new SqlDataColumn
                                {
                                    DefaultValue = row["DefaultValue"],
                                    IsPKey = Convert.ToBoolean(row["IsPrimaryKey"]),
                                    Name = Convert.ToString(row["name"]),
                                    Nullable = !Convert.ToBoolean(row["NotNull"]),
                                    Type = Convert.ToString(row["type"])
                                };

                                Columns.Add(col);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        public SqlDataView()
        {
            Columns = new List<SqlDataColumn>();
        }
    }

    public class SqlDataIndex : ISqlDataObject
    {
        public List<SqlDataColumn> Columns { get; set; }
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string TableName { get; set; }

        public void GetColumns(SqlDatabaseConnection con)
        {
            Columns = new List<SqlDataColumn>();

            var sql = "SYSCMD Index_Info('" + Name + "')";
            using (var cmd = new SqlDatabaseCommand(sql, con))
            {
                using (var dt = new DataTable("IndexSchema"))
                {
                    using (var da = new SqlDatabaseDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            var col = new SqlDataColumn
                            {
                                Name = Convert.ToString(row["ColumnName"])
                            };

                            Columns.Add(col);
                        }
                    }
                }
            }
        }
    }

    public class SqlDataTable : ISqlDataObject
    {
        public string ConnectionString { get; set; }

        public SqlDataTable()
        {
            Columns = new List<SqlDataColumn>();
        }

        public string Name { get; set; }

        public string TableName { get; set; }

        public List<SqlDataColumn> Columns { get; set; }

        public void GetColumns(SqlDatabaseConnection con)
        {
            var sql = "SYSCMD table_info('" + Name + "')";
            using (var cmd = new SqlDatabaseCommand(sql, con))
            {
                using (var dt = new DataTable("Schema"))
                {
                    using (var da = new SqlDatabaseDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            var col = new SqlDataColumn
                            {
                                DefaultValue = row["DefaultValue"],
                                IsPKey = Convert.ToBoolean(row["IsPrimaryKey"]),
                                Name = Convert.ToString(row["name"]),
                                Nullable = !Convert.ToBoolean(row["NotNull"]),
                                Type = Convert.ToString(row["type"])
                            };

                            Columns.Add(col);
                        }
                    }
                }
            }
        }
    }
}
