using Code.Gameplay.Environment.Behaviour;
using Code.Gameplay.Environment.Config;
using Code.Gameplay.ObjectPool.Service;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Gameplay.Environment.Factory
{
  public class EnvironmentFactory : IEnvironmentFactory
  {
    private readonly IObjectPoolService _objectPool;
    private readonly IStaticDataService _staticDataService;

    public EnvironmentFactory(IObjectPoolService objectPool, IStaticDataService staticDataService)
    {
      _objectPool = objectPool;
      _staticDataService = staticDataService;
    }

    public void CreateEnvironment()
    {
      EnvironmentConfig config = _staticDataService.GetEnvironmentConfig();

      EnvironmentItem item = _objectPool.Get<EnvironmentItem>(config.ViewPrefab, Vector3.zero);

      item.Initialize(config.ViewPrefab, config.BorderThikness, config.BorderPadding);
    }
  }
}