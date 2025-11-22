using Code.Common.Extensions;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
	public class BrickCollider : MonoBehaviour
	{
		[SerializeField] private BrickItem _item;

		private IScoreService _scoreService;
		private IBrickProvider _brickProvider;
		private ILevelCompleter _levelCompleter;

		[Inject]
		public void Constructor(IScoreService scoreService, IBrickProvider brickProvider, ILevelCompleter levelCompleter)
		{
			_scoreService = scoreService;
			_brickProvider = brickProvider;
			_levelCompleter = levelCompleter;
		}


		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.MatchesCollisions(CollisionLayer.Ball.AsMask()))
			{
				IncreaseScore();
				RecalculateBrickCount();
			}
		}

		private void IncreaseScore() => 
			_scoreService.IncreaseScore(_item.ScoreValue);

		private void RecalculateBrickCount()
		{
			_brickProvider.RemoveBrick(_item);

			if( _brickProvider.GetBricks().Count <= 0)
				_levelCompleter.CompleteLevel();
		}
	}
}