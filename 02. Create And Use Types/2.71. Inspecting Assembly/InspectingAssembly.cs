using System;
using System.Linq;
using System.Reflection;

public class MyApplication { }

public interface IPlugin
{
    string Name { get; }

    string Description { get; }

    bool Load(MyApplication application);
}

public class MyPlugin : IPlugin
{
    public string Name
    {
        get
        {
            return "My Plugin";
        }
    }

    public string Description
    {
        get
        {
            return "My Sample Plugin";
        }
    }

    public bool Load(MyApplication application)
    {
        return true;
    }
}

class InspectingAssembly
{
    static void Main()
    {
        Assembly pluginAssembly = Assembly.Load("2.71. Inspecting Assembly");

        var plugins = from type in pluginAssembly.GetTypes()
                      where typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface
                      select type;

        foreach (Type pluginType in plugins)
        {
            IPlugin plugin = Activator.CreateInstance(pluginType) as IPlugin;
        }
    }
}