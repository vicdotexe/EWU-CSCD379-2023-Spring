using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameResultController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<GameResult> Get()
        {
            return new List<GameResult>();
        }
    }
}
