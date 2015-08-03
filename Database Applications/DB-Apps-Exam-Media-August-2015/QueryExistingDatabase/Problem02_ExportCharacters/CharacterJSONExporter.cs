using System.IO;
using System.Linq;
using EntityFrameworkMapping;
using Newtonsoft.Json;

public class CharacterJSONExporter
{
    public static void Main()
    {
        var context = new DiabloEntities();

        var characters = context.Characters
            .OrderBy(c => c.Name)
            .Select(c => new
            {
                c.Name,
                Players = c.UsersGames.Select(u => u.User.Username)
            });

        var charactersJson = JsonConvert.SerializeObject(characters, Formatting.Indented);
        File.WriteAllText("..//..//characters.json", charactersJson);
    }
}