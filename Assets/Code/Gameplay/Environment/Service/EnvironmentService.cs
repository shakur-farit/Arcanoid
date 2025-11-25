using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class EnvironmentService : IEnvironmentService, ICleanable
  {
    private EnvironmentItem _environment;

    public void SetEnvironment(EnvironmentItem environment) =>
      _environment = environment;

    public void Clean() =>
      Object.Destroy(_environment.gameObject);
  }
}