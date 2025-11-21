using UnityEngine;

namespace Code.Gameplay.Environment
{
  [CreateAssetMenu(menuName = "Arcanoid/Environment Config", fileName = "EnvironmentConfig")]
  public class EnvironmentConfig : ScriptableObject
  {
    public GameObject ViewPrefab;
    public float BorderThikness;
    public float BorderPadding;
  }
}