using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services;
using Bonafoot.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bonafoot.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<IEnumerable<GameContract>> GetAll()
        {
            return await _gameService.GetAll();
        }

        [HttpPost]
        public async Task<GameContract> Post(NewGameCommand command)
        {
            return await _gameService.New(command);
        }
    }
}
