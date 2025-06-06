namespace Personal_Finance_Manager.Exceptions
{
    public class InvalidExpenseException : System.Exception
    {
        public InvalidExpenseException(string message) : base(message) { }
    }
}
