using System.Collections.Generic;

public class Folder
{
    private ICollection<Folder> childFolders;

    public Folder()
    {
        this.childFolders = new HashSet<Folder>();
    }

    public string Name { get; set; }

    public File[] Files { get; set; }

    public ICollection<Folder> ChildFolders 
    { 
        get
        {
            return this.childFolders;
        }

        set
        {
            this.childFolders = value;
        }
    }
}