using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class PlayerService
    {
        private readonly AppDbContext _db;

        public PlayerService(AppDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _db.Players.ToListAsync();
        }

        public async Task<Player?> GetPlayer(int playerId)
        {
            return await _db.Players
                .Where(p => p.PlayerId == playerId)
                .Include(p => p.GameResults)
                .FirstOrDefaultAsync();
        }

        public async Task<Player> CreatePlayer()
        {
            Player player = new() { Name = "Guest" };
            await _db.Players.AddAsync(player);
            await _db.SaveChangesAsync();
            return player;
        }
    }
}   
