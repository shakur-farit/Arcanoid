using Code.Common.Extensions;
using Code.Gameplay.Brick.Service;
using Code.Gameplay.Level.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Brick.Behaviour
{
	public class BrickCollider : MonoBehaviour
	{
		[SerializeField] private BrickItem _item;
		[SerializeField] private BrickSoundEffectPlayer _soundEffectPlayer;
		[SerializeField] private BrickLootDropper _lootDropper;
		[SerializeField] private ScoreIncreaser _scoreIncreaser;

		private IBrickService _brickService;
		private ILevelCompleter _levelCompleter;

    [Inject]
		public void Constructor(IBrickService brickService, ILevelCompleter levelCompleter)
		{
			_brickService = brickService;
			_levelCompleter = levelCompleter;
    }


		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.MatchesCollisions(CollisionLayer.Ball.AsMask()))
			{
				DropLoot();
				IncreaseScore();
				RecalculateBrickCount();
				PlaySoundEffect();
			}
		}

    private void IncreaseScore() => 
			_scoreIncreaser.IncreaseScore(_item.ScoreValue);

    private void RecalculateBrickCount()
		{
			_brickService.RemoveBrick(_item);

			if( _brickService.GetBricks().Count <= 0)
				_levelCompleter.CompleteLevel();
		}

    private void PlaySoundEffect() => 
      _soundEffectPlayer.PlaySoundEffect();

    private void DropLoot() => 
			_lootDropper.DropLoot(_item.ExcludedLoot, transform.position);
  }
}