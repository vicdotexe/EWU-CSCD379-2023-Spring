﻿using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Dtos;
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

    [HttpGet]
    public async Task<ActionResult<PlayerDto>> Get(int id)
    {
        Player? player = await _ps.GetPlayer(id);

        if (player is not null)
        {
            return player.MapToDto();
        }
        return BadRequest();

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

    [HttpPost("setname")]
    public async Task<Player?> ChangeName(int playerId, string name)
    {
        return await _ps.ChangeName(playerId, name);
    }
}
