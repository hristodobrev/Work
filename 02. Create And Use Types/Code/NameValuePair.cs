namespace Code
{
    public class NameValuePair
    {
        public int Value { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.Name, this.Value);
        }
    }
}
