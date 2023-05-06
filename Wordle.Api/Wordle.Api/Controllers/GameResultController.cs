using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameResultController : ControllerBase
    {
        private GameResultService _grs;

        public GameResultController(GameResultService grs) 
        { 
            _grs = grs;
        }

        [HttpGet]
        public IEnumerable<GameResult> Get()
        {
            return new List<GameResult>();
        }
        [HttpPost]
        public async Task<ActionResult<GameResult>> Post(GameResult result)
        {
            return await _grs.SaveGameResult(result);
        }
    }
}
