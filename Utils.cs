using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDatabase.Net.Explorer
{
    using SQLDatabase.Net.SQLDatabaseClient;
    using System.Data;

    public static class Utils
    {
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)) return false;

            var ascii1 = Convert.ToByte(name[0]);
            // only A..z and _ are valid for first letter
            var valid1 = (ascii1 >= 65 && ascii1 <= 90)  || (ascii1 >= 97 && ascii1 <= 122) || ascii1 == 95;
            if (!valid1) return false;

            foreach (char c in name)
            {
                var ascii = Convert.ToByte(c);
                // allow A..z, 0..9 and underscore in the rest of the name
                var valid = (ascii >= 65 && ascii <= 90) || (ascii >= 97 && ascii <= 122) || (ascii >= 48 && ascii <= 57) || ascii == 95;
                if (!valid) return false;
            }

            return true;
        }

        public static void RestoreTableFromBackup(DataTable backupTable, SqlDatabaseConnection connection, SqlDatabaseTransaction transaction)
        {
            var fields = new List<string>();
            var parameters = new List<string>();
            using (var cmd = new SqlDatabaseCommand(connection))
            {
                foreach (DataRow row in backupTable.Rows)
                {
                    cmd.Parameters.Clear();

                    foreach (DataColumn col in row.Table.Columns)
                    {
                        var paramName = "@" + col.ColumnName;
                        fields.Add(col.ColumnName);
                        cmd.Parameters.Add(paramName, row[col]);
                        parameters.Add(paramName);
                    }

                    var insertSql = "INSERT INTO " + backupTable.TableName;
                    insertSql += "(" + string.Join(",", fields) + ")";
                    insertSql += "\nVALUES\n";
                    insertSql += "(" + string.Join(",", parameters) + ")";

                    cmd.CommandText = insertSql;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string GetCreateSql(ISqlDataObject templateTable)
        {
            var createSql = "DROP TABLE IF EXISTS " + templateTable.Name + ";\n"+
                "CREATE TABLE " + templateTable.Name + "\n(";
            var fields = new List<string>();
            foreach (var col in templateTable.Columns.Where(o => !string.IsNullOrEmpty(o.Name)))
            {
                var s = "\n" + col.Name + " " + col.Type;
                if (!col.Nullable || col.IsPKey) { s += " NOT NULL"; }
                if (col.IsPKey) s += " PRIMARY KEY";
                if (col.IsPKey && col.AutoInc) s += " AUTOINCREMENT ";
                var sDefault = Convert.ToString(col.DefaultValue);
                if (sDefault == "''") sDefault = string.Empty;

                if (!col.AutoInc && col.DefaultValue != null && col.DefaultValue != DBNull.Value && !string.IsNullOrEmpty(sDefault))
                {
                    s += " DEFAULT ";
                    if (col.Type.ToUpper() == "TEXT" && !sDefault.StartsWith("'"))
                    {
                        sDefault = "'" + sDefault + "'";
                    }

                    s += sDefault;
                }

                fields.Add(s);
            }

            createSql += string.Join(",", fields);
            createSql += "\n)";

            return createSql.Replace("\n", "\r\n");
        }

        public static void CreateTableFromDefinition(ISqlDataObject templateTable, SqlDatabaseConnection connection)
        {
            var createSql = GetCreateSql(templateTable);

            if (connection != null)
            {
                    using (var cmd = new SqlDatabaseCommand(createSql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
            }
        }
    }
}
