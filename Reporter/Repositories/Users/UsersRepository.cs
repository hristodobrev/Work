using Reporter.IO;
using Reporter.Models.Users;
using Reporter.Services;

using System.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Reporter.Repositories.Users
{
    public class UsersRepository : IRepository<User>
    {
        private string folderName = "Repositories";
        private string fileName = "users.rp";

        private IReader reader;
        private IWriter writer;

        private ICryptoService cryptoService = new CryptoService();

        private JavaScriptSerializer serializer = new JavaScriptSerializer();

        public UsersRepository()
        {
            this.reader = new FileReader(this.folderName, this.fileName);
            this.writer = new FileWriter(this.folderName, this.fileName);
        }

        public int GetNextId()
        {
            IEnumerable<User> users = this.GetAllItems();
            if (users.Count() == 0)
            {
                return 0;
            }

            return users.Max(u => u.Id) + 1;
        }

        public User GetItemById(int id)
        {
            string records = this.reader.Read();
            IList<User> users = this.GetAllItems().ToList();

            return users.FirstOrDefault(p => p.Id == id);
        }

        public void AddItem(User item)
        {
            item.Id = this.GetNextId();
            item.Password = this.cryptoService.GetHash(item.Password);

            string records = this.reader.Read();
            IList<User> users = this.GetAllItems().ToList();

            users.Add(item);

            records = this.serializer.Serialize(users);
        }

        public IEnumerable<User> GetAllItems()
        {
            string records = this.reader.Read();
            List<User> users = this.serializer.Deserialize<List<User>>(records);

            if (users == null)
            {
                users = new List<User>();
            }

            return users;
        }
    }
}
