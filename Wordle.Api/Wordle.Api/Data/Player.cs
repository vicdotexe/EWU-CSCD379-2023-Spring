using Wordle.Api.Dtos;

namespace Wordle.Api.Data;

public class Player
{
    public int PlayerId { get; set; }
    public required string Name { get; set; }
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }
    public int AverageSecondsPerGame { get; set; }
    public ICollection<GameResult> GameResults { get; set; } = new List<GameResult>();

    public static void SeedPlayers(AppDbContext db)
    {
        if (!db.Players.Any())
        {
            Player player = new() { Name = "Victor" };
            db.Players.Add(player);
            db.SaveChanges();
        }
    }
}

public static class Extentions
{
    public static PlayerDto MapToDto(this Player player)
    {
        PlayerDto dto = new()
        {
            PlayerId = player.PlayerId,
            Name = player.Name,
            GameCount = player.GameCount,
            AverageAttempts = player.AverageAttempts,
            AverageSecondsPerGame = player.AverageSecondsPerGame,
            GameResults = player.GameResults.Select(x => x.MapToDto()).ToList()
        };
        return dto;
    }

    public static void Update(this Player player, PlayerDto dto)
    {
        if (dto.Name is not null)
        {
            player.Name = dto.Name;
        }
    }

    public static GameResultDto MapToDto(this GameResult gameResult)
    {
        GameResultDto dto = new()
        {
            GameResultId = gameResult.GameResultId,
            PlayerId = gameResult.PlayerId,
            PlayerName = gameResult.Player?.Name,
            Attempts = gameResult.Attempts,
            Duration = gameResult.Duration,
            Score = gameResult.Score,
            Success = gameResult.Success,
        };

        return dto;
    }
}
