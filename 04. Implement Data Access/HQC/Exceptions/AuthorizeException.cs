using System;
using HQC.Models;
namespace HQC.Exceptions
{
    public class AuthorizeException : Exception
    {
        public AuthorizeException(string message)
            : base(message)
        {

        }

        public AuthorizeException(string message, UserRole role)
            : base(message)
        {
            this.Role = role;
        }

        public UserRole Role { get; set; }
    }
}
