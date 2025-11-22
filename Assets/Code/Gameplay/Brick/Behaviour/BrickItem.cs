using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
	public class BrickItem : MonoBehaviour
	{
		[SerializeField] private Transform _brickTransform;

		private IBrickService _brickService;

		public int ScoreValue { get; private set; }

		[Inject]
		public void Constructor(IBrickService brickService) => 
			_brickService = brickService;

		public void Initialize(float width, float height, int scoreValue)
		{
			_brickTransform.localScale = new Vector2(width, height);
			ScoreValue = scoreValue;

			_brickService.AddBrick(this);
		}
	}
}