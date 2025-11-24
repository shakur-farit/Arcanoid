using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
	[CreateAssetMenu(menuName = "Arcanoid/Brick Config", fileName = "BrickConfig")]
	public class BrickConfig : ScriptableObject
	{
		public GameObject ViewPrefab;
		[Range(0, 1000)] public int ScoreValue;
    public IEnumerable<LootTypeId> ExcludedLoot;

  }
}