using UnityEngine;

namespace Code.Common.Extensions
{

  public enum CollisionLayer
  {
    Paddle = 6,
    Brick = 7,
    GameOverBorder = 9,
    Ball = 10
  }

  public static class CollisionExtensions
  {
    public static bool MatchesColliders(this Collider2D collider, LayerMask layerMask) =>
      ((1 << collider.gameObject.layer) & layerMask) != 0;

    public static bool MatchesCollisions(this Collision2D collision, LayerMask layerMask) =>
	    ((1 << collision.gameObject.layer) & layerMask) != 0;

		public static int AsMask(this CollisionLayer layer) =>
      1 << (int)layer;
  }
}