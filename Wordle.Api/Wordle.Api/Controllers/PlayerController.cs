using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _ps;
    public PlayerController(PlayerService ps)
    {
        _ps = ps;
    }

    [HttpGet()]
    public async Task<Player?> Get(int id)
    {
        return await _ps.GetPlayer(id);
    }

    [HttpGet("list")]
    public async Task<IEnumerable<Player>> Get()
    {
        return await _ps.GetPlayers();
    }

    [HttpPost]
    public async Task<Player> Post()
    {
        return await _ps.CreatePlayer();
    }
}
