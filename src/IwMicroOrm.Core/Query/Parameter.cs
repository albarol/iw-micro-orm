namespace IwMicroOrm.Core.Query
{
    public class Parameter
    {
        public Parameter(string column)
        {
            this.Column = column;
        }

        public Parameter()
        {
        }
        
        public string Column { get; set; }
        public object Value { get; set; }
    }
}
