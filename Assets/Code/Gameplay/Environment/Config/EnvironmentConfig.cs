using UnityEngine;

namespace Code.Gameplay.Environment.Config
{
  [CreateAssetMenu(menuName = "Arcanoid/Environment Config", fileName = "EnvironmentConfig")]
  public class EnvironmentConfig : ScriptableObject
  {
    public GameObject ViewPrefab;
    public float BorderThikness;
    public float BorderPadding;
  }
}