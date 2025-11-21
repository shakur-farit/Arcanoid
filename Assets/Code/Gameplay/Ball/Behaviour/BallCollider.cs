using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class BallCollider : MonoBehaviour
  {
    private const float MinBounce = 0.2f;

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private BallItem _item;

    private void OnCollisionEnter2D(Collision2D _) => 
      AdjustAngle();

    private void AdjustAngle()
    {
      Vector2 dir = _rigidbody2D.velocity.normalized;

      if (Mathf.Abs(dir.x) < MinBounce)
        dir.x = Mathf.Sign(dir.x) * MinBounce;

      if (Mathf.Abs(dir.y) < MinBounce)
        dir.y = Mathf.Sign(dir.y) * MinBounce;

      _rigidbody2D.velocity = dir.normalized * _item.MovementSpeed;
    }
  }
}