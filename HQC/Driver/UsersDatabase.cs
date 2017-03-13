using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HQC.Models;

namespace HQC.Driver
{
    public class UsersDatabase : IDatabase
    {
        private string databaseFolder;
        private string databaseName;

        public UsersDatabase(string databaseFolder = "../../Database", string databaseName = "users.db")
        {
            this.databaseFolder = databaseFolder;
            this.databaseName = databaseName;

            if (!Directory.Exists(this.databaseFolder))
            {
                Directory.CreateDirectory(this.databaseFolder);
            }
            if (!File.Exists(this.databaseFolder + "/" + this.databaseName))
            {
                File.Create(this.databaseFolder + "/" + this.databaseName);
            }
        }

        public bool CreateUser(Models.IUser user)
        {
            try
            {
                string userInfo = user.Id + ";" + user.Username + ";" + user.Password + ";" + user.Email + ";" + user.Role;
                
                using (StreamWriter file = new StreamWriter(this.databaseFolder + "/" + this.databaseName, true))
                {
                    file.WriteLine(userInfo);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IUser GetUserById(int id)
        {
            IEnumerable<IUser> users = this.GetAllUsers();

            return users.FirstOrDefault(u => u.Id == id);
        }

        public IUser GetUserByUsername(string username)
        {
            IEnumerable<IUser> users = this.GetAllUsers();

            return users.FirstOrDefault(u => u.Username == username);
        }

        public int GetNextId()
        {
            IEnumerable<IUser> users = this.GetAllUsers();

            if (users.Count() == 0)
            {
                return 1;
            }

            return users.Max(u => u.Id) + 1;
        }


        public bool UserExists(string username)
        {
            return this.GetUserByUsername(username) != null;
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            string data = string.Empty;
            using (StreamReader file = new StreamReader(this.databaseFolder + "/" + this.databaseName))
            {
                data = file.ReadToEnd();
            }

            List<IUser> users = new List<IUser>();
            foreach (string line in data.Split('\n'))
            {
                if (line.Trim() == "")
                {
                    continue;
                }

                string[] args = line.Split(';');
                UserRole role = (UserRole)Enum.Parse(typeof(UserRole), args[4]);
                users.Add(new User(int.Parse(args[0]), args[1], args[2], args[3], role));
            }

            return users;
        }
    }
}
