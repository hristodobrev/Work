using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CovarianceAndContravariance
{
    public delegate TextWriter CovarianceDel();

    public delegate void ContravarianceDel(StreamWriter tw);

    static void Main()
    {
        CovarianceDel del = MethodStream;

        ContravarianceDel contradel = DoSomething;
    }

    public static void DoSomething(TextWriter tw)
    {

    }

    public static StreamWriter MethodStream()
    {
        return null;
    }

    public static StringWriter MethodString()
    {
        return null;
    }
}