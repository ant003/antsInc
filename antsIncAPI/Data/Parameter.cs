namespace antsIncAPI.Data
{
    /**
     * Represents a parameter for the stored procedure
     */
    public class Parameter
    {
        /**
         * Name: the name of the stored procedure parameter
         * Value: the value for such stored procedure parameter
         */
        public Parameter(string name, string value)
        {
            Name = name; 
            Value = value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
