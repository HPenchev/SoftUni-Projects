using System;
using System.Text.RegularExpressions;



static class HTMLDispatcher
{
    public static string CreateImage(string imageSource, string alt, string title)
    {
        ElementBuilder element = new ElementBuilder("img");
        element.AddAttribute("src", imageSource);
        element.AddAttribute("alt", alt);
        element.AddAttribute("title", title);
        string tag = element * 1;
        Regex regex = new Regex(@"<[^>]+>");
        Match match = regex.Match(tag);
        return match.Value;
    }
    public static string CreateURL(string url, string text, string title)
    {
         ElementBuilder element = new ElementBuilder("a");
         element.AddAttribute("href", url);
         element.AddContent(text);
         element.AddAttribute("title", title);
         return (element * 1);
    }
    public static string CreateInput(string type, string name, string value)
    {
        ElementBuilder element = new ElementBuilder("input");
        element.AddAttribute("type", type);
        element.AddAttribute("name", name);
        element.AddAttribute("value", value);
        string tag = element * 1;
        Regex regex = new Regex(@"<[^>]+>");
        Match match = regex.Match(tag);
        return match.Value;
    }


}

