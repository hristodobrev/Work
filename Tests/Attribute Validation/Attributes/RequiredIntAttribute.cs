namespace Attribute_Validation.Attributes
{
    using System;

    public class RequiredIntAttribute : Attribute
    {
        public RequiredIntAttribute(int equals)
        {
            this.Equals = equals;
            this.IsEquals = true;
        }

        public RequiredIntAttribute(int min, int max)
        {
            this.Min = min;
            this.Max = max;
            this.IsEquals = false;
        }

        public bool IsEquals { get; private set; }

        public int Equals { get; private set; }

        public int Min { get; private set; }

        public int Max { get; private set; }
    }
}
