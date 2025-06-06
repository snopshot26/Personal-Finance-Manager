namespace Personal_Finance_Manager.Exceptions
{
    public class UserAlreadyExistsException : System.Exception
    {
        public UserAlreadyExistsException(string username)
            : base($"User '{username}' already exists.") { }
    }
}
