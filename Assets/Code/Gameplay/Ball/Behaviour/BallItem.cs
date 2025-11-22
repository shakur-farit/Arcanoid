using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class BallItem : MonoInstallerBase
  {
	  private IBallProvider _ballProvider;

	  public float MovementSpeed { get; private set; }
    public Vector2 StartDirection { get; private set; }

    [Inject]
    public void Constructor(IBallProvider ballProvider) => 
	    _ballProvider = ballProvider;

    public void Initialize(float movementSpeed, Vector2 startDirection)
    {
      MovementSpeed = movementSpeed;
      StartDirection = startDirection;

      _ballProvider.SetBall(this);
    }
  }
}