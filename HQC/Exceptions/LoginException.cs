using System;
namespace HQC.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException(string message)
            : base(message)
        {

        }
    }
}
