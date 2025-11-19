using Code.Infrastructure.StaticData;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class EnvironmentFactory : IEnvironmentFactory
  {
    private readonly IInstantiator _instantiator;
    private readonly IStaticDataService _staticDataService;

    public EnvironmentFactory(IInstantiator instantiator, IStaticDataService staticDataService)
    {
      _instantiator = instantiator;
      _staticDataService = staticDataService;
    }

    public void CreateEnvironment()
    {
      EnvironmentConfig config = _staticDataService.GetEnvironmentConfig();

      _instantiator.InstantiatePrefab(config.ViewPrefab);
    }
  }
}