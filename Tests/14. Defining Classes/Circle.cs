public class Circle
{
    public static double PI = 3.141592653589793;

    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public static double CalculateSurface(double radius)
    {
        return (PI * radius * radius);
    }

    public void PrintSurface()
    {
        double surface = CalculateSurface(this.radius);
        System.Console.WriteLine("Circle's surface is: " + surface);
    }
}