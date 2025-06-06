namespace Personal_Finance_Manager.Exceptions
{
    public class InvalidCredentialsException : System.Exception
    {
        public InvalidCredentialsException() : base("Invalid credentials.") { }
    }
}
