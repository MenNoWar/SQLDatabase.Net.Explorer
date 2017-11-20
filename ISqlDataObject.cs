using System.Collections.Generic;
using SQLDatabase.Net.SQLDatabaseClient;

namespace SQLDatabase.Net.Explorer
{
    public interface ISqlDataObject
    {
        List<SqlDataColumn> Columns { get; set; }
        string ConnectionString { get; set; }
        string Name { get; set; }

        string TableName { get; set; }
        void GetColumns(SqlDatabaseConnection con);
    }
}