namespace Code
{
    public class Hero
    {
        public const int defaultHealth = 5;

        public readonly string defaultName = "Gosho";

        public Hero()
        {

        }

        public Hero(string name)
        {
            this.defaultName = name;
        }
    }
}
