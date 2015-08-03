using System;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Threading;
using EntityFrameworkMapping;

public class UserGamesXMLImporter
{
    public static void Main()
    {  
        Thread.CurrentThread.CurrentCulture = new CultureInfo("DE-de");
        var context = new DiabloEntities();

        XmlDocument docUsers = new XmlDocument();
        docUsers.Load("..//..//..//..//data//users-and-games.xml");
        string usersPath = "/users/user";
        XmlNodeList userNodes = docUsers.SelectNodes(usersPath);
        string gamesPath = "games/game";

        foreach (XmlNode userNode in userNodes)
        {
            string username = userNode.Attributes["username"].Value;
            User user = context.Users.Where(u => u.Username == username).FirstOrDefault();

            if (user != null)
            {
                Console.WriteLine("User {0} already exists", user.Username);
                continue;
            }

            user = new User()
            {
                FirstName = userNode.Attributes["first-name"] != null ?
                userNode.Attributes["first-name"].Value
                : null,
                LastName = userNode.Attributes["last-name"] != null ?
                userNode.Attributes["last-name"].Value
                : null,
                Username = username,
                Email = userNode.Attributes["email"] != null ?
                userNode.Attributes["email"].Value
                : null,
                IpAddress = userNode.Attributes["ip-address"].Value,
                IsDeleted = Convert.ToBoolean(int.Parse(userNode.Attributes["is-deleted"].Value)),
                RegistrationDate = DateTime.Parse(userNode.Attributes["registration-date"].Value)
            };                      

            context.Users.Add(user);

            XmlNodeList xmlGames = userNode.SelectNodes(gamesPath);
            foreach (XmlNode xmlGame in xmlGames)
            {
                string gameName = xmlGame.SelectSingleNode("game-name").InnerText;
                string characterName = xmlGame.SelectSingleNode("character").Attributes["name"].Value;
                decimal cash = decimal.Parse(xmlGame.SelectSingleNode("character").Attributes["cash"].Value);
                int level = int.Parse(xmlGame.SelectSingleNode("character").Attributes["level"].Value);
                DateTime joinedOn = DateTime.Parse(xmlGame.SelectSingleNode("joined-on").InnerText);

                var userGame = new UsersGame()
                {
                    //Game name is a non-unique field in the database and duplicates exist. For the task we
                    //admit that we take the first game with this name.
                    Game = context.Games.Where(g => g.Name == gameName).First(),
                    User = user,
                    Character = context.Characters.Where(c => c.Name == characterName).First(),
                    Cash = cash,
                    Level = level,
                    JoinedOn = joinedOn
                }; 
               
                context.UsersGames.Add(userGame);
            }

            context.SaveChanges();
            
            //As per the problem terms we can't add a user if any of his games fail to add.
            //That's why we save changes after all the UserGames are in context. If agame fails to add, 
            //the user won't be added. We print the user and its games only in case of a successful add in 
            //the context

            var addedUser = context.Users
                .Where(u => u.Username == username)                
                .Select(u => new
                {
                    u.Username,
                    UserGames = u.UsersGames.Select(ug => ug.Game.Name)
                })
                .First();

            Console.WriteLine("Successfully added user " + addedUser.Username);
            foreach (var game in user.UsersGames)
            {
                Console.WriteLine("User {0} successfully added to game {1}", user.Username, game.Game.Name);
            }
        }
    }
}