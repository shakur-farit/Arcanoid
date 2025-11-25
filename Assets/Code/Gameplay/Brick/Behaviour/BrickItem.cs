using System.Collections.Generic;
using Code.Gameplay.Brick.Service;
using Code.Gameplay.Loot;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Brick.Behaviour
{
	public class BrickItem : MonoBehaviour
	{
		[SerializeField] private Transform _brickTransform;

		private IBrickService _brickService;

		public GameObject ViewPrefab { get; private set; }
		public int ScoreValue { get; private set; }
    public IEnumerable<LootTypeId> ExcludedLoot { get; private set; }

    [Inject]
		public void Constructor(IBrickService brickService) => 
			_brickService = brickService;

		public void Initialize(GameObject viewPrefab, float width, float height, int scoreValue, IEnumerable<LootTypeId> excludedLoot)
    {
      ViewPrefab = viewPrefab;
			_brickTransform.localScale = new Vector2(width, height);
			ScoreValue = scoreValue;
      ExcludedLoot = excludedLoot;

			_brickService.AddBrick(this);
		}
	}
}