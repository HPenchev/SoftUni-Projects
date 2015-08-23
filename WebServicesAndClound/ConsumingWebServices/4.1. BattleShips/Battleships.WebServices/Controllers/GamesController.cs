namespace Battleships.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Web.Http;

    using Battleships.Data;
    using Battleships.Models;
    using Battleships.WebServices.Infrastructure;
    using Battleships.WebServices.Models;

    [Authorize]
    public class GamesController : BaseApiController
    {
        private const int numberOfShips = 10;
        private const int xMax = 8;
        private const int yMax = 8;
        private IUserIdProvider userIdProvider;
        private static Random rnd = new Random();
               
        public GamesController(IBattleshipsData data, IUserIdProvider userIdProvider) 
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        public IHttpActionResult GetGamesCount()
        {
            var gamesCount = this.Data.Games.All().Count();
            return this.Ok(gamesCount);
        }

        [HttpPost]
        [ActionName("create")]
        public IHttpActionResult CreateGame()
        {
            var userId = this.userIdProvider.GetUserId();
            var game = new Game
            {
                PlayerOneId = userId,                
            };

            GenerateShips(game, userId);

            this.Data.Games.Add(game);
            this.Data.SaveChanges();

            return this.Ok(game.Id);
        }

        [HttpGet]
        [ActionName("available")]
        public IHttpActionResult GetAllAvailableGames()
        {
            var games = this.Data.Games
                .All()
                .Where(x => x.State == GameState.WaitingForPlayer)
                .Select(x => new
                {
                    x.Id,
                    PlayerOne = x.PlayerOne.UserName,
                    State = x.State.ToString(),
                })
                .ToList();

            return this.Ok(games);
        }

        [HttpPost]
        [ActionName("join")]
        public IHttpActionResult JoinGame(JoinGameBindingModel model)
        {
            var guidGameId = new Guid(model.GameId);
            var game = this.Data.Games
                .All()
                .FirstOrDefault(x => x.Id == guidGameId);
            if (game == null)
            {
                return this.NotFound();
            }

            var userId = this.userIdProvider.GetUserId();
            if (game.PlayerOneId == userId)
            {
                return this.BadRequest("You can not join in your game!");
            }

            game.PlayerTwoId = userId;
            game.State = GameState.TurnOne;

            this.Data.SaveChanges();

            return this.Ok(game.Id);
        }

        [HttpPost]
        [ActionName("play")]
        public IHttpActionResult PlayTurn(PlayTurnBindingModel model)
        {
            if (model == null)
            {
                this.ModelState.AddModelError("model", "The model is empty");
            }

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var guidGameId = new Guid(model.GameId);
            var game = this.Data.Games
                .All()
                .FirstOrDefault(x => x.Id == guidGameId);
            if (game == null)
            {
                return this.NotFound();
            }

            var userId = this.userIdProvider.GetUserId();
            if (game.PlayerOneId != userId && game.PlayerTwoId != userId)
            {
                return this.BadRequest("You can't make turn in this game!");
            }

            if ((game.PlayerOneId == userId && game.State == GameState.TurnTwo) || 
                (game.PlayerTwoId == userId && game.State == GameState.TurnOne))
            {
                return this.BadRequest("It's not your turn!");
            }

            var fieldSideLength = (int)Math.Sqrt(game.Field.Length);
            if (model.PositionX >= fieldSideLength || model.PositionY >= fieldSideLength)
            {
                return this.BadRequest("Invalid position!");
            }

            var fieldPosition = model.PositionX + (model.PositionY * fieldSideLength);
            if (game.Field[fieldPosition] == 'X')
            {
                return this.BadRequest("Position already bombed!");
            }

            var field = new StringBuilder(game.Field);
            field[fieldPosition] = 'X';
            game.Field = field.ToString();
            game.State = game.State == GameState.TurnOne ? GameState.TurnTwo : GameState.TurnOne;
            this.Data.SaveChanges();

            return this.Ok();
        }

        private void GenerateShips(Game game, string playerId)
        {
            while (true)
            {
                int numberOfShipsInGame = game.Ships.Where(s => s.Player.Id.ToString() == playerId).Count();
                if (numberOfShipsInGame >= numberOfShips)
                {
                    break;
                }

                int x = rnd.Next(xMax);
                int y = rnd.Next(xMax);

                if (!game.Ships.Any(s => s.PositionX == x && s.PositionY == y))
                {
                    var ship = new Ship()
                    {
                        PositionX = x,
                        PositionY = y,
                        Game = game,
                        Player = this.Data.Users.Find(playerId)
                    };

                    game.Ships.Add(ship);
                }               
            }
        }
    }
}