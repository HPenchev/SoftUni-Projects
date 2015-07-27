using System;
using System.IO;
using System.Linq;

public class Program
{
    private static DirectoryInfo Info = new DirectoryInfo("C:\\Windows");

    private static Folder windowsFolderInfo = TakeFolderInfo(Info);

    static void Main()
    {
        Folder folder = GetSubfolderByName(windowsFolderInfo, "C:\\Windows\\Branding");

        long size = GetSize(folder);

        Console.WriteLine(size);

        Console.ReadLine();
    }

    private static Folder GetSubfolderByName(Folder folder, string name)
    {
        if (folder.Name == name)
        {
            return folder;
        }

        
        Folder folderSearched = null;
        foreach (var child in folder.ChildFolders)
        {
            folderSearched = GetSubfolderByName(child, name);
            if (folderSearched != null)
            {
                return folderSearched;
            }
        }

        return null;
    }
    
    private static long GetSize(Folder folder)
    {
        long totalSize = folder.Files.Sum(f => f.Size);
        foreach (Folder subfolder in folder.ChildFolders)
        {
            totalSize += GetSize(subfolder);
        }

        return totalSize;
    }

    private static Folder TakeFolderInfo(DirectoryInfo info)
    {
        
        var files = info.GetFiles();
        Folder folder = new Folder();
        folder.Name = info.FullName;

        File[] filesInformation = new File[files.Length];

        for (int i = 0; i < files.Length; i++)
        {
            filesInformation[i] = new File();
            filesInformation[i].Name = files[i].Name;
            filesInformation[i].Size = files[i].Length;
        }

        folder.Files = filesInformation;

        DirectoryInfo[] subFolders = info.GetDirectories();

        foreach (var subFolder in subFolders)
        {
            folder.ChildFolders.Add(TakeFolderInfo(subFolder));
        }

        return folder;
    }
}