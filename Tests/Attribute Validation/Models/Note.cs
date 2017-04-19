namespace Attribute_Validation.Models
{
    using Attribute_Validation.Attributes;

    public class Note
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
