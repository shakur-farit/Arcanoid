using Code.Common.Extensions;
using Code.Gameplay.Ball.Service;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Ball.Behaviour
{
  public class GameOverCollider : MonoBehaviour
  {
	  [SerializeField] private BallItem _item;

    private IGameStateMachine _gameStateMachine;
    private IBallService _ballService;

    [Inject]
    public void Constructor(IGameStateMachine gameStateMachine, IBallService ballService)
    {
	    _gameStateMachine = gameStateMachine;
	    _ballService = ballService;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
	    if (collision.MatchesCollisions(CollisionLayer.GameOverBorder.AsMask()))
	    {
        RemoveBall();

        if(_ballService.GetBalls().Count <=0)
					EnterGameOverState();
	    }
    }

    private void RemoveBall() => 
	    _ballService.RemoveBall(_item);

    private void EnterGameOverState() =>
      _gameStateMachine.Enter<GameOverState>();
  }
}