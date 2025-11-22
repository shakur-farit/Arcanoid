using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class EnvironmentService : IEnvironmentService, IRemovable
  {
    private EnvironmentItem _environment;

    public void SetEnvironment(EnvironmentItem environment) =>
      _environment = environment;

    public void Remove() =>
      Object.Destroy(_environment.gameObject);
  }
}