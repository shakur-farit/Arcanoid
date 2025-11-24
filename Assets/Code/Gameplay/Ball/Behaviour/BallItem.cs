	using UnityEngine;
	using Zenject;

	namespace Code.Gameplay.Environment
	{
	  public class BallItem : MonoInstallerBase
	  {
		  private IBallService _ballService;

		  public float MovementSpeed { get; private set; }
	    public Vector2 StartDirection { get; private set; }

	    [Inject]
	    public void Constructor(IBallService ballService) => 
		    _ballService = ballService;

	    public void Initialize(float movementSpeed, Vector2 startDirection)
	    {
	      MovementSpeed = movementSpeed;
	      StartDirection = startDirection;

	      _ballService.SetBall(this);
	    }
	  }
	}