namespace BattleshipsConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;

    public static class CommandProcessor
    {
        private const string LocalHost = "http://localhost:62858/";
        private static string token = null;

        public static void ProcessCommand(string input)
        {
            string[] commands = input.Split(' ');

            if (commands[0] != "$")
            {
                Console.WriteLine("Commands have to start with $");
                return;
            }

            string command = commands[1];            
            switch (command)
            {
                case "register":
                    RegisterUser(commands[2], commands[3], commands[4]);
                    break;
                case "login":
                    LoginUser(commands[2], commands[3]);
                    break;
                case "create-game":
                    CreateGame();
                    break;
                case "join-game":
                    JoinGame(commands[2]);
                    break;
                case "play":
                    PlayTurn(commands[2], commands[3], commands[4]);
                    break;
                default:
                    Console.WriteLine("Unknow command " + commands[1]);
                    break;
            }

            //throw new System.NotImplementedException();
            //return result;
        }

        private static async void RegisterUser(
            string email,
            string password,
            string confirmPassword)
        {
            string endPoint = LocalHost + "api/account/register";
            var client = new HttpClient();
            
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("confirmPassword", confirmPassword),
            });

            var response = await client.PostAsync(endPoint, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("User {0} successfully registered", email));
            }
            else
            {
                Console.WriteLine(response.ReasonPhrase);
            }
        }

        private static async void LoginUser(string username, string password)
        {
            string endPoint = LocalHost + "Token";
            var client = new HttpClient();

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            });

            var response = await client.PostAsync(endPoint, content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var responseJson = 
                    serializer.Deserialize<Dictionary<string, string>>(responseString);
                token = responseJson["access_token"];                
                Console.WriteLine(string.Format("User {0} successfully logged", username));
            }
            else
            {
                Console.WriteLine(response.ReasonPhrase);
            }
        }

        private static async void CreateGame()
        {
            string endPoint = LocalHost + "api/Games/create";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        
            var response = await client.PostAsync(endPoint, null);

            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();                
                Console.WriteLine(string.Format("Game {0} successfully created", id));
            }
            else
            {
                Console.WriteLine(response.ReasonPhrase);
            }
        }

        private static async void JoinGame(string gameId)
        {
            string endPoint = LocalHost + "api/Games/join";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("gameId", gameId)                
            });
            
            var response = await client.PostAsync(endPoint, content);

            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                Console.WriteLine("You have successfully joined the game");
            }
            else
            {
                Console.WriteLine(response.ReasonPhrase);
            }
        }

        private static async void PlayTurn(string gameId, string x, string y)
        {
            string endPoint = LocalHost + "api/Games/play";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("gameId", gameId),
                new KeyValuePair<string, string>("positionX", x),
                new KeyValuePair<string, string>("positionY", y),
            });

            var response = await client.PostAsync(endPoint, content);

            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                Console.WriteLine("You have successfully bombarded position {0} {1}", x, y);
            }
            else
            {
                Console.WriteLine(response.ReasonPhrase);
            }
        }
    }
}