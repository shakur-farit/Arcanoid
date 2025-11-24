using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
	public class BrickItem : MonoBehaviour
	{
		[SerializeField] private Transform _brickTransform;

		private IBrickService _brickService;

		public int ScoreValue { get; private set; }
    public IEnumerable<LootTypeId> ExcludedLoot { get; private set; }

    [Inject]
		public void Constructor(IBrickService brickService) => 
			_brickService = brickService;

		public void Initialize(float width, float height, int scoreValue, IEnumerable<LootTypeId> excludedLoot)
		{
			_brickTransform.localScale = new Vector2(width, height);
			ScoreValue = scoreValue;
      ExcludedLoot = excludedLoot;

			_brickService.AddBrick(this);
		}
	}
}