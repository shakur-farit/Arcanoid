using Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class BallFactory : IBallFactory
  {
    private readonly IInstantiator _instantiator;
    private readonly IStaticDataService _staticDataService;
    private readonly IBallMovementSpeedService _movementSpeed;

    public BallFactory(
	    IInstantiator instantiator, 
	    IStaticDataService staticDataService,
	    IBallMovementSpeedService movementSpeed)
    {
      _instantiator = instantiator;
      _staticDataService = staticDataService;
      _movementSpeed = movementSpeed;
    }

    public void CreateBall()
    {
      BallConfig config = _staticDataService.GetBallConfig();

      BallItem item = _instantiator.InstantiatePrefabForComponent<BallItem>(
        config.ViewPrefab, config.StartPosition, Quaternion.identity, null);

      item.Initialize(GetMovementSpeed(config), config.StartDirection);
    }

    private float GetMovementSpeed(BallConfig config) => 
	    _movementSpeed.GetMovementSpeed(config.MovementSpeed);
  }
}