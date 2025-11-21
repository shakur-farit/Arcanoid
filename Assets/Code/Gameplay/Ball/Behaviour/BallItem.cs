using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class BallItem : MonoInstallerBase
  {
    public float MovementSpeed { get; private set; }
    public Vector2 StartDirection { get; private set; }

    public void Initialize(float movementSpeed, Vector2 startDirection)
    {
      MovementSpeed = movementSpeed;
      StartDirection = startDirection;
    }
  }
}