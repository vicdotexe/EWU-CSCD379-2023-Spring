using System.ComponentModel.DataAnnotations.Schema;

namespace Wordle.Api.Data;

public class GameResult
{
    public int GameResultId { get; set; }
    public int PlayerId { get; set; }
    [ForeignKey(nameof(PlayerId))]
    public Player? Player { get; set; }
    public int Attempts { get; set; }
    public double Duration { get; set; }
    public double Score => CalculateScore();
    public bool Success { get; set; }

    private double CalculateScore()
    {
        if (!Success) return 0;

        double score = 100 - (Attempts * 5);
        score -= Duration / 2000;
        return score;
    }
}
