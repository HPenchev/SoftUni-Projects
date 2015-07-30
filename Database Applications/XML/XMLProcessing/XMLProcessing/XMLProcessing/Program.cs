using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

public class Program
{
    public static void Main()
    {        
        XmlDocument catalogueFile = new XmlDocument();
        catalogueFile.Load("..//..//..//..//catalogue.xml");

        XDocument file = XDocument.Load("..//..//..//..//catalogue.xml");

        //ICollection<string> albums = DisplayAllAlbumNames(catalogueFile);
        //foreach (var album in albums)
        //{
        //    System.Console.WriteLine(album);
        //}

        //SortedSet<string> artists = ExtractAllArtistsAlphabetically(catalogueFile);

        //foreach (var artist in artists)
        //{
        //    System.Console.WriteLine(artist);
        //}

        IDictionary<string, int> artistsAlbums = ExtractAllArtistsAndNumberOfAlbums(catalogueFile);

        //foreach (KeyValuePair<string, int> artist in artistsAlbums)
        //{
        //    System.Console.WriteLine(artist.Key + " - " + artist.Value + " albums");
        //}

        //artistsAlbums = ExtractAllArtistsAndNumberOfAlbumsUsingPath(catalogueFile);

        //foreach (KeyValuePair<string, int> artist in artistsAlbums)
        //{
        //    System.Console.WriteLine(artist.Key + " - " + artist.Value + " albums");
        //}

        //ExtractCheapAlbums(catalogueFile);

        IDictionary<string, decimal> albumPrices = ReturnOldAlbums(catalogueFile);

        //foreach (KeyValuePair<string, decimal> album in albumPrices)
        //{
        //    Console.WriteLine(album.Key + " - " + album.Value);
        //}

        //albumPrices = ReturnOldAlbumsByLinq(file);
        //foreach (KeyValuePair<string, decimal> album in albumPrices)
        //{
        //    Console.WriteLine(album.Key + " - " + album.Value);
        //}

        DirectoryInfo directory = new DirectoryInfo("D:\\Movies");
        ExtractDirectoryInfo(directory);
    }

    //Problem 2.	DOM Parser: Extract Album Names

    public static ICollection<string> DisplayAllAlbumNames(XmlDocument catalogueFile)
    {
        XmlNode catalogue = catalogueFile.DocumentElement;

        IList<string> albums = new List<string>();

        foreach (XmlNode album in catalogue.ChildNodes)
        {
            albums.Add(album["name"].InnerText);
        }

        return albums;
    }

    //Problem 3.	DOM Parser: Extract All Artists Alphabetically

    public static SortedSet<string> ExtractAllArtistsAlphabetically(XmlDocument catalogueFile)
    {
        XmlNode catalogue = catalogueFile.DocumentElement;
        SortedSet<string> artists = new SortedSet<string>();

        foreach (XmlNode album in catalogue.ChildNodes)
        {
            artists.Add(album["artist"].InnerText);
        }

        return artists;
    }

    //Problem 4.	DOM Parser: Extract Artists and Number of Albums

    public static IDictionary<string, int> ExtractAllArtistsAndNumberOfAlbums(XmlDocument catalogueFile)
    {
        XmlNode catalogue = catalogueFile.DocumentElement;
        IDictionary<string, int> artistsAlbums = new Dictionary<string, int>();

        foreach (XmlNode album in catalogue.ChildNodes)
        {
            if (artistsAlbums.ContainsKey(album["artist"].InnerText))
            {
                artistsAlbums[album["artist"].InnerText] = artistsAlbums[album["artist"].InnerText] + 1;
            }
            else
            {
                artistsAlbums[album["artist"].InnerText] = 1;
            }
        }

        return artistsAlbums;
    }

    //Problem 5.	XPath: Extract Artists and Number of Albums

    public static IDictionary<string, int> ExtractAllArtistsAndNumberOfAlbumsUsingPath(XmlDocument catalogueFile)
    {
        XmlNode catalogue = catalogueFile.DocumentElement;
        IDictionary<string, int> artistsAlbums = new Dictionary<string, int>();
        string path = "/catalogue/album/artist";
        XmlNodeList artists = catalogue.SelectNodes(path);

        foreach (XmlNode artist in artists)
        {
            if (artistsAlbums.ContainsKey(artist.InnerText))
            {
                artistsAlbums[artist.InnerText] = artistsAlbums[artist.InnerText] + 1;
            }
            else
            {
                artistsAlbums[artist.InnerText] = 1;
            }
        }
        
        return artistsAlbums;
    }

    //Problem 6.	DOM Parser: Delete Albums

    public static void ExtractCheapAlbums(XmlDocument catalogueFile)
    {
        XmlNode catalogue = catalogueFile.DocumentElement;

        for (int i = 0; i < catalogue.ChildNodes.Count; i++)
        {
            if (decimal.Parse(catalogue.ChildNodes[i]["price"].InnerText) > 20)
            {
                catalogue.RemoveChild(catalogue.ChildNodes[i]);
                i--;
            }
        }        

        catalogueFile.Save("..//..//..//..//cheap-albums-catalogue.xml");
    }

    //Problem 7.	DOM Parser and XPath: Old Albums

    public static IDictionary<string, decimal> ReturnOldAlbums(XmlDocument catalogueFile)
    {
        XmlNode catalogue = catalogueFile.DocumentElement;
        int yearToSearch = DateTime.Now.Year - 5;
        string path = "/catalogue/album[year <= " + yearToSearch + "]";
        var albums = catalogue.SelectNodes(path);
        IDictionary<string, decimal> albumsPrices = new Dictionary<string, decimal>();

        foreach (XmlNode album in albums)
        {
            albumsPrices[album["name"].InnerText] = decimal.Parse(album["price"].InnerText);
        }

        return albumsPrices;
    }

    //Problem 8.	LINQ to XML: Old Albums

    public static IDictionary<string, decimal> ReturnOldAlbumsByLinq(XDocument catalogueFile)
    {
        IDictionary<string, decimal> albumPrices = new Dictionary<string, decimal>();

        var albums = catalogueFile
            .Descendants("album")
            .Where(a => int.Parse(a.Element("year").Value) <= 2010)
            .Select(a => new
                        {
                            Name = a.Element("name").Value,
                            Price = decimal.Parse(a.Element("price").Value)
                        });

         foreach (var album in albums)
         {
             albumPrices[album.Name] = album.Price;
         }

         return albumPrices;
    }
    
    //Problem 10.	XElement: Directory Contents as XML

    public static void ExtractDirectoryInfo(DirectoryInfo directory)
    {

        XElement root = ReturnDirectoryInfo(directory, true);
        
        XDocument doc = new XDocument();
        doc.Add(root);

        doc.Save("..//..//..//..//directory-info.xml");
    }

    private static XElement ReturnDirectoryInfo(DirectoryInfo directory, bool isRoot)
    {
        XElement directoryInfo = null;

        if (isRoot)
        {
            directoryInfo = new XElement("root-directory", new XAttribute("path", directory.FullName));
        }
        else
        {
            directoryInfo = new XElement("dir", new XAttribute("name", directory.Name));
        }

        foreach (var subfolder in directory.GetDirectories())
        {
            directoryInfo.Add(ReturnDirectoryInfo(subfolder, false));
        }

        foreach (var file in directory.GetFiles())
        {
            directoryInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
        }

        return directoryInfo;
    }
}