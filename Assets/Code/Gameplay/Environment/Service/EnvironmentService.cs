using Code.Gameplay.Environment.Behaviour;
using Code.Gameplay.Level.Service;
using Code.Gameplay.ObjectPool.Service;

namespace Code.Gameplay.Environment.Service
{
  public class EnvironmentService : IEnvironmentService, ICleanable
  {
    private EnvironmentItem _environment;

    private readonly IObjectPoolService _objectPool;

    public EnvironmentService(IObjectPoolService objectPool) => 
      _objectPool = objectPool;

    public void SetEnvironment(EnvironmentItem environment) =>
      _environment = environment;

    public void Clean() =>
      _objectPool.Return(_environment.ViewPrefab, _environment.gameObject);
  }
}