using UnityEngine;

namespace Code.Gameplay.Environment
{
  [CreateAssetMenu(menuName = "Arcanoid/Grid Config", fileName = "GridConfig")]
  public class GridConfig : ScriptableObject
  {
    [Range(0.1f, 10f)] public float CellWidth;
		[Range(0.1f, 10f)] public float CellHeight;
		[Range(0.1f, 10f)] public float TopPadding;
		[Range(0.1f, 10f)] public float RightPadding;
		[Range(0.1f, 10f)] public float LeftPadding;
  }
}