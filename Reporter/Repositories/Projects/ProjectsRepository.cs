using System.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;

using Reporter.Repositories;
using Reporter.Models.Projects;
using Reporter.IO;

namespace Reporter.Repositories.Projects
{
    public class ProjectsRepository : IRepository<Project>
    {
        private string folderName = "Repositories";
        private string fileName = "projects.rp";

        private IReader reader;
        private IWriter writer;

        private JavaScriptSerializer serializer = new JavaScriptSerializer();

        public ProjectsRepository()
        {
            this.reader = new FileReader(this.folderName, this.fileName);
            this.writer = new FileWriter(this.folderName, this.fileName);
        }

        public int GetNextId()
        {
            IEnumerable<Project> projects = this.GetAllItems();
            if (projects.Count() == 0)
            {
                return 0;
            }

            return projects.Max(p => p.Id) + 1;
        }

        public Project GetItemById(int id)
        {
            string records = this.reader.Read();
            List<Project> projects = this.GetAllItems().ToList();

            return projects.FirstOrDefault(p => p.Id == id);
        }

        public void AddItem(Project item)
        {
            item.Id = this.GetNextId();

            string records = this.reader.Read();
            List<Project> projects = this.GetAllItems().ToList();

            projects.Add(item);

            records = this.serializer.Serialize(projects);
        }

        public IEnumerable<Project> GetAllItems()
        {
            string records = this.reader.Read();
            List<Project> projects = this.serializer.Deserialize<List<Project>>(records);

            if (projects == null)
            {
                projects = new List<Project>();
            }

            return projects;
        }
    }
}
