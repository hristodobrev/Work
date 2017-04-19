using System;

namespace Code
{
    [Flags]
    public enum Days
    {
        None = 0x0,
        Sun = 0x1,
        Mon = 0x2,
        Tue = 0x4,
        Wed = 0x8,
        Thu = 0x10,
        Fri = 0x20,
        Sat = 0x40
    }
}