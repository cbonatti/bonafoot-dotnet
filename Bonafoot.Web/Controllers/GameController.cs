using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services;
using Bonafoot.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bonafoot.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameService _gameService;
        public GameController()
        {
            _gameService = new GameService();
        }

        [HttpPost]
        public GameContract Post(NewGameCommand command)
        {
            return _gameService.New(command);
        }
    }
}
