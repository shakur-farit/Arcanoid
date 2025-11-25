using Code.Gameplay.Ball.Service;
using Code.Gameplay.Score.Service;

namespace Code.Gameplay.Restart
{
  public class RestartingService : IRestartingService
  {
    private readonly IScoreService _scoreService;
    private readonly IBallMovementSpeedService _ballMovementSpeedService;

    public RestartingService(IScoreService scoreService, IBallMovementSpeedService ballMovementSpeedService)
    {
	    _scoreService = scoreService;
	    _ballMovementSpeedService = ballMovementSpeedService;
    }

    public void Restart()
    {
	    ResetScore();
	    ResetBallMovementSpeed();
    }

    private void ResetScore() => 
	    _scoreService.ResetScore();

    private void ResetBallMovementSpeed() => 
	    _ballMovementSpeedService.ResetSpeed();
  }
}