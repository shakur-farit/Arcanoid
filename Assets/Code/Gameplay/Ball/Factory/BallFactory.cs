using Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class BallFactory : IBallFactory
  {
    private readonly IInstantiator _instantiator;
    private readonly IStaticDataService _staticDataService;

    public BallFactory(IInstantiator instantiator, IStaticDataService staticDataService)
    {
      _instantiator = instantiator;
      _staticDataService = staticDataService;
    }

    public void CreateBall()
    {
      BallConfig config = _staticDataService.GetBallConfig();

      BallItem item = _instantiator.InstantiatePrefabForComponent<BallItem>(
        config.ViewPrefab, config.StartPosition, Quaternion.identity, null);

      item.Initialize(config.MovementSpeed, config.StartDirection);
    }
  }
}