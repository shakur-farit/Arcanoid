using UnityEngine;

namespace Code.Gameplay.Environment
{
  [CreateAssetMenu(menuName = "Arcanoid/Ball Config", fileName = "BallConfig")]
  public class BallConfig : ScriptableObject
  {
    public GameObject ViewPrefab;
    [Range(0f, 100f)] public float MovementSpeed;
    public Vector2 StartPosition;
    public Vector2 StartDirection;
  }
}