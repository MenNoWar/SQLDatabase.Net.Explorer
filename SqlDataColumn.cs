using System;

namespace SQLDatabase.Net.Explorer
{
    public class SqlDataColumn
    {
        public override string ToString()
        {
            return Name;
        }
        public string Type { get; set; }
        public string Name { get; set; }
        public bool Nullable { get; set; }
        public object DefaultValue { get; set; }
        public bool IsPKey { get; set; }             
        public bool AutoInc { get; set; }

        public static Type SqlTypeToType(string sqlType)
        {
            sqlType = sqlType.ToUpper().Trim();
            switch (sqlType)
            {
                case "INTEGER":
                    return typeof(int);
                case "TEXT":
                    return typeof(string);
                case "REAL":
                    return typeof(double);
                case "BLOB":
                    return typeof(byte[]);
                case "NONE":
                    return typeof(object);
            }

            throw new Exception("Unknown columntype: '" + sqlType + "'");
        }
    }
}
