using System;
using System.IO;
using System.Security.AccessControl;

class SettingAccessControlForADirectory
{
    static void Main()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo("ADTestDirectory");
        directoryInfo.Create();
        DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
        directorySecurity.AddAccessRule(
            new FileSystemAccessRule("everyone",
                FileSystemRights.Read,
                AccessControlType.Deny));

        directoryInfo.SetAccessControl(directorySecurity);
    }
}