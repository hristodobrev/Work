using System;

class UsingAccessModifiers
{
    static void Main()
    {
        Student st = new Student("Penka");
        st.AppendToName(" Vasileva");
        st.SayName();
    }
}
