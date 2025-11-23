using Code.Common.Extensions;
using Code.Infrastructure.States.GameStates;
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
    private ISoundEffectFactory _soundEffectFactory;

    [Inject]
		public void Constructor(
      IScoreService scoreService, 
      IBrickService brickService, 
      ISoundEffectFactory soundEffectFactory, 
      ILevelCompleter levelCompleter)
		{
			_scoreService = scoreService;
			_brickService = brickService;
			_levelCompleter = levelCompleter;
      _soundEffectFactory = soundEffectFactory;
    }


		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.MatchesCollisions(CollisionLayer.Ball.AsMask()))
			{
				IncreaseScore();
				RecalculateBrickCount();
				PlaySoundEffect();
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

    private void PlaySoundEffect() => 
      _soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.BrickBroken);
  }
}