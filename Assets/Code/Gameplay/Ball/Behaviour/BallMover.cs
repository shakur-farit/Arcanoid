using UnityEngine;

namespace Code.Gameplay.Ball.Behaviour
{
  public class BallMover : MonoBehaviour
  {
    [SerializeField] private BallItem _item;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Vector2 _direction;

    private void Start() => 
      LaunchBall();

    private void FixedUpdate() => 
      Move();

    private void LaunchBall()
    {
      _direction = _item.StartDirection.normalized;
      _rigidbody2D.velocity = _direction * _item.MovementSpeed;
    }

    private void Move() => 
      _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * _item.MovementSpeed;
  }
}