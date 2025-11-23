using Code.Gameplay.Environment;

namespace Code.Gameplay.Restart
{
  public class RestartingService : IRestartingService
  {
    private readonly IScoreService _scoreService;

    public RestartingService(IScoreService scoreService) => 
      _scoreService = scoreService;

    public void Restart() => 
      _scoreService.RestartScore();
  }
}