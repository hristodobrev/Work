using System;
using System.IO;

class ImplementDriveInformation
{
    static void Main()
    {
        DriveInfo[] drivesInfo = DriveInfo.GetDrives();

        foreach (DriveInfo driveInfo in drivesInfo)
        {
            Console.WriteLine("Drive {0}", driveInfo.Name);
            Console.WriteLine("  File type: {0}", driveInfo.DriveType);

            if (driveInfo.IsReady)
            {
                Console.WriteLine("{0,35}   {1}", "Volume label:", driveInfo.VolumeLabel);
                Console.WriteLine("{0,35}   {1}", "File system:", driveInfo.DriveFormat);
                Console.WriteLine(
                    "{0,35}   {1:0.00}GB ({2} bytes)",
                    "Available space to current user:", driveInfo.AvailableFreeSpace / 1000000000.0, driveInfo.AvailableFreeSpace);
                Console.WriteLine(
                    "{0,35}   {1:0.00}GB ({2} bytes)",
                    "Total available space:", driveInfo.TotalFreeSpace / 1000000000.0, driveInfo.TotalFreeSpace);
                Console.WriteLine(
                    "{0,35}   {1:0.00}GB ({2} bytes)", "Total size of drive:", driveInfo.TotalSize / 1000000000.0, driveInfo.TotalSize);
            }
        }
    }
}