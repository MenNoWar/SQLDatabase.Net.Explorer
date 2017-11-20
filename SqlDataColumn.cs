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
    }
}
