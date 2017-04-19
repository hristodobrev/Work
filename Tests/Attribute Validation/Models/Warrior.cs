namespace Attribute_Validation.Models
{
    using Attribute_Validation.Attributes;

    public class Warrior
    {
        [RequiredInt(0, 100)]
        public int Health { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [BeforeInvoke]
        public void Attack()
        {
            System.Console.WriteLine("The warrior has done some damage to the enemy!");
        }
    }
}
