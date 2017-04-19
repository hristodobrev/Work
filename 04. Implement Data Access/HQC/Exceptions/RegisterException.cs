using System;
namespace HQC.Exceptions
{
    public class RegisterException : Exception
    {
        public RegisterException(string message)
            : base(message)
        {

        }
    }
}
