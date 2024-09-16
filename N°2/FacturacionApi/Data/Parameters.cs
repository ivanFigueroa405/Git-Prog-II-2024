namespace FacturacionApi.Data
{
    public class Parameters
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public Parameters(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
