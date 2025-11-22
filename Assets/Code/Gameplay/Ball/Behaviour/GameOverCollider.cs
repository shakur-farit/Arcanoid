using Code.Common.Extensions;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class GameOverCollider : MonoBehaviour
  {
    private IGameStateMachine _gameStateMachine;

    [Inject]
    public void Constructor(IGameStateMachine gameStateMachine) =>
      _gameStateMachine = gameStateMachine;

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.MatchesCollisions(CollisionLayer.GameOverBorder.AsMask()))
        EnterGameOverState();
    }

    private void EnterGameOverState() =>
      _gameStateMachine.Enter<GameOverState>();
  }
}