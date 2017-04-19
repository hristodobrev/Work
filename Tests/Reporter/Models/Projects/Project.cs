using System.Web.Script.Serialization;
namespace Reporter.Models.Projects
{
    public class Project : IRecord<Project>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
