using Code.Gameplay.Ball.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Ball.Behaviour
	{
	  public class BallItem : MonoInstallerBase
	  {
		  private IBallService _ballService;

		  public GameObject ViewPrefab { get; private set; }
		  public float MovementSpeed { get; private set; }
	    public Vector2 StartDirection { get; private set; }

	    [Inject]
	    public void Constructor(IBallService ballService) => 
		    _ballService = ballService;

	    public void Initialize(GameObject viewPrefab, float movementSpeed, Vector2 startDirection)
      {
        ViewPrefab = viewPrefab;
	      MovementSpeed = movementSpeed;
	      StartDirection = startDirection;

	      _ballService.SetBall(this);
	    }
	  }
	}