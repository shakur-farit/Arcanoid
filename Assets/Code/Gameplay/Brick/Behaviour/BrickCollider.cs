using Code.Common.Extensions;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
	public class BrickCollider : MonoBehaviour
	{
		[SerializeField] private BrickItem _item;

		private IScoreService _scoreService;
		private IBrickService _brickService;
		private ILevelCompleter _levelCompleter;

		[Inject]
		public void Constructor(IScoreService scoreService, IBrickService brickService, ILevelCompleter levelCompleter)
		{
			_scoreService = scoreService;
			_brickService = brickService;
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
			_brickService.RemoveBrick(_item);

			if( _brickService.GetBricks().Count <= 0)
				_levelCompleter.CompleteLevel();
		}
	}
}