using System;

class Point
{
    private double x;
    private double y;

    private double[] coords;

    public Point(int x, int y)
    {
        this.coords = new double[2];
        this.coords[0] = x;
        this.coords[1] = y;

        this.x = x;
        this.y = y;
    }

    public double X
    {
        get
        {
            return this.coords[0];
        }

        set
        {
            this.coords[0] = value;
        }
    }

    public double Y
    {
        get
        {
            return this.y;
        }

        set
        {
            this.y = value;
        }
    }
}