using System.Collections.Generic;
using HQC.Models;

namespace HQC.Driver
{
    public interface IDatabase
    {
        bool CreateUser(IUser user);

        IUser GetUserById(int id);

        IUser GetUserByUsername(string username);

        IEnumerable<IUser> GetAllUsers();

        bool UserExists(string username);

        int GetNextId();
    }
}
