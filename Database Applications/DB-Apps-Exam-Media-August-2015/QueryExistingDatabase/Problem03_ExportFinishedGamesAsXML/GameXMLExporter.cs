using System.Linq;
using System.Xml.Linq;
using EntityFrameworkMapping;

public class GameXMLExporter
{
    public static void Main()
    {
        var context = new DiabloEntities();

        var games = context.Games
            .OrderBy(g => g.Name)
            .ThenBy(g => g.Duration)
            .Select(g => new
            {
                g.Name,
                g.Duration,
                Users = g.UsersGames.Select(u => new
                {
                    Username = u.User.Username,
                    IpAdress = u.User.IpAddress
                })
            });

        XElement xmlGames = new XElement("games");
        foreach (var game in games)
        {
            XElement xmlGame = new XElement("game", new XAttribute("name", game.Name));
            if (game.Duration != null)
            {
                xmlGame.Add(new XAttribute("duration", game.Duration));
            }

            XElement xmlUsers = new XElement("users");
            foreach (var user in game.Users)
            {
                XElement xmlUser = new XElement("user",
                    new XAttribute("username", user.Username),
                    new XAttribute("ip-address", user.IpAdress));

                xmlUsers.Add(xmlUser);
            }

            xmlGame.Add(xmlUsers);
            xmlGames.Add(xmlGame);
        }

        XDocument docGames = new XDocument(xmlGames);
        docGames.Save("..//..//games.xml");
    }
}