using UnityEngine;

namespace Code.Gameplay.Environment
{
  [CreateAssetMenu(menuName = "Arcanoid/Grid Config", fileName = "GridConfig")]
  public class GridConfig : ScriptableObject
  {
    public int CellSize;
  }
}