namespace HQC.Session
{
    public interface ISessionManager
    {
        bool SessionKeyExists(string key);

        void AddSession(string key, object value);

        object GetSession(string key);

        void DeleteSession(string key);
    }
}
