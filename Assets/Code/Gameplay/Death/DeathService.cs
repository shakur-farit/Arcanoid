using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Gameplay.Death
{
  public class DeathService : IDeathService
  {
    public void Die(GameObject gameObject) => 
      Object.Destroy(gameObject);
  }
}