using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
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
        public GameController(IGameService gameService) => _gameService = gameService;

        [HttpGet]
        public async Task<IEnumerable<GameContract>> GetAll() => await _gameService.GetAll();

        [HttpGet, Route("load")]
        public async Task<GameContract> Get(string name) => await _gameService.Load(new LoadGameCommand() { Name = name });

        [HttpPost]
        public async Task<GameContract> Post(NewGameCommand command) => await _gameService.New(command);

        [HttpDelete]
        public async Task<bool> Delete(DeleteGameCommand command) => await _gameService.Delete(command);
    }
}
