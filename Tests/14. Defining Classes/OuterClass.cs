using System;

public class OuterClass
{
    private string name;

    private OuterClass(string name)
    {
        this.name = name;
    }

    private class InnerClass
    {
        private string name;
        private OuterClass parent;

        public InnerClass(OuterClass parent, string name)
        {
            this.parent = parent;
            this.name = name;
        }

        public void PrintNames()
        {
            Console.WriteLine("Nested name: " + this.name);
            Console.WriteLine("Outer name: " + this.parent.name);
        }
    }

    // Rename this method to Main
    public static void NotMain()
    {
        OuterClass outerClass = new OuterClass("outer");
        InnerClass innerClass = new InnerClass(outerClass, "inner");
        innerClass.PrintNames();
    }
}