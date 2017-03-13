using System.Collections.Generic;
using HQC.Exceptions;
namespace HQC.Session
{
    public class SessionManager : ISessionManager
    {
        private Dictionary<string, object> session;

        public SessionManager()
        {
            this.session = new Dictionary<string, object>();
        }

        public bool SessionKeyExists(string key)
        {
            return this.session.ContainsKey(key);
        }

        public void AddSession(string key, object value)
        {
            this.session[key] = value;
        }

        public object GetSession(string key)
        {
            if (!this.session.ContainsKey(key))
            {
                throw new SessionException("Key does not exists", key);
            }

            return this.session[key];
        }

        public void DeleteSession(string key)
        {
            if (!this.session.ContainsKey(key))
            {
                throw new SessionException("Key does not exists", key);
            }

            this.session.Remove(key);
        }

        public override string ToString()
        {
            string result = "";
            foreach (var item in this.session)
            {
                result += item.Key + ":" + item.Value + "\n";
            }

            return result;
        }
    }
}
