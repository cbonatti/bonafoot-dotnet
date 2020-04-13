using Bonafoot.Core.Commands;
using Bonafoot.Core.Contracts;
using Bonafoot.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bonafoot.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        IMatchService _service;
        public MatchController(IMatchService service) => _service = service;

        [HttpPost]
        public async Task<ChampionshipContract> PlayGame(PlayMatchCommand command) => await _service.Play(command);
    }
}
