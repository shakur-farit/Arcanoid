using Code.Gameplay.Ball.Behaviour;
using Code.Gameplay.Ball.Config;
using Code.Gameplay.Ball.Service;
using Code.Gameplay.ObjectPool.Service;
using Code.Infrastructure.StaticData;

namespace Code.Gameplay.Ball.Factory
{
  public class BallFactory : IBallFactory
  {
    private readonly IObjectPoolService _objectPool;
    private readonly IStaticDataService _staticDataService;
    private readonly IBallMovementSpeedService _movementSpeed;

    public BallFactory(
	    IObjectPoolService objectPool, 
	    IStaticDataService staticDataService,
	    IBallMovementSpeedService movementSpeed)
    {
      _objectPool = objectPool;
      _staticDataService = staticDataService;
      _movementSpeed = movementSpeed;
    }

    public void CreateBall()
    {
      BallConfig config = _staticDataService.GetBallConfig();

      BallItem item = _objectPool.Get<BallItem>(config.ViewPrefab, config.StartPosition);

      item.Initialize(config.ViewPrefab, GetMovementSpeed(config), config.StartDirection);
    }

    private float GetMovementSpeed(BallConfig config) => 
	    _movementSpeed.GetMovementSpeed(config.MovementSpeed);
  }
}