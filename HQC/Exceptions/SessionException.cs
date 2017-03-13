using System;
namespace HQC.Exceptions
{
    public class SessionException : Exception
    {
        public SessionException(string message)
            : base(message)
        {

        }
        public SessionException(string message, string key)
            : base(message)
        {
            this.Key = key;
        }

        public string Key { get; set; }
    }
}
