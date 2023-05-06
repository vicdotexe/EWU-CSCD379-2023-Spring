namespace Wordle.Api.Dtos
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public int GameCount { get; set; }
        public int AverageAttempts { get; set; }
        public double AverageSecondsPerGame { get; set; }
        public List<GameResultDto> GameResults { get; set; } = new List<GameResultDto>();
    }
}
