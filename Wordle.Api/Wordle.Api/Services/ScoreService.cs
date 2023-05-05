using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class GameResultService
    {
        private readonly AppDbContext _db;

        public GameResultService(AppDbContext db)
        {
            _db = db;
        }

        public async Task SaveGameResult(GameResult result)
        {
            _db.Add(result);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameResult>> GetTopScores(int count = 10)
        {
            return await _db.GameResults
                .OrderByDescending(gr => gr.Score)
                .Take(count)
                .Include(gr => gr.Player)
                .ToListAsync();
        }
    }
}
