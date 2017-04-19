namespace SomeAssembly
{
    public interface ITestable
    {
        int TestFailsCount { get; }

        bool TestSuccess { get; }

        bool Test();
    }
}
