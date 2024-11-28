using System;
using System.IO;
using System.Security.AccessControl;

class Program
{
    static void Main(string[] args)
    {
        try
        {
           
            string baseFolderPath = @"C:\MySharedFolders";

         
            if (!Directory.Exists(baseFolderPath))
            {
                Directory.CreateDirectory(baseFolderPath);
                Console.WriteLine($"Base folder created: {baseFolderPath}");
            }

           
            Console.Write("Enter the subfolder name to create or modify: ");
            string subfolderName = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(subfolderName))
            {
                Console.WriteLine("Subfolder name cannot be empty.");
                return;
            }

           
            string folderPath = Path.Combine(baseFolderPath, subfolderName);

            Console.Write("Enter the group name to grant permissions to: ");
            string groupName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(groupName))
            {
                Console.WriteLine("Group name cannot be empty.");
                return;
            }

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine($"Subfolder created: {folderPath}");
            }
            else
            {
                Console.WriteLine($"Subfolder already exists: {folderPath}");
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

            FileSystemAccessRule accessRule = new FileSystemAccessRule(
                groupName,
                FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                AccessControlType.Allow);

            directorySecurity.AddAccessRule(accessRule);

        
            directoryInfo.SetAccessControl(directorySecurity);
            Console.WriteLine($"Permissions granted to group: {groupName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

