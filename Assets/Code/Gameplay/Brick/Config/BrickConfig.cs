using UnityEngine;

namespace Code.Gameplay.Environment
{
	[CreateAssetMenu(menuName = "Arcanoid/Brick Config", fileName = "BrickConfig")]
	public class BrickConfig : ScriptableObject
	{
		public GameObject ViewPrefab;
	}
}