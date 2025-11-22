using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
	public class BrickItem : MonoBehaviour
	{
		[SerializeField] private Transform _brickTransform;

		private IBrickProvider _brickProvider;

		public int ScoreValue { get; private set; }

		[Inject]
		public void Constructor(IBrickProvider brickProvider) => 
			_brickProvider = brickProvider;

		public void Initialize(float width, float height, int scoreValue)
		{
			_brickTransform.localScale = new Vector2(width, height);
			ScoreValue = scoreValue;

			_brickProvider.AddBrick(this);
		}
	}
}