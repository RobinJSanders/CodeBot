namespace Code_Bot.Logic
{
    public class StoredVar
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }



        public StoredVar(string type, string name, string value)
        {
            Type = type;
            Name =name;
            Value = value;
        }
    }
}