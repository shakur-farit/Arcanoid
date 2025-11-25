using Code.Infrastructure.States.GameStates;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Brick.Behaviour
{
  public class BrickSoundEffectPlayer : MonoBehaviour
  {
    private ISoundEffectFactory _soundEffectFactory;

    [Inject]
    public void Constructor(ISoundEffectFactory soundEffectFactory) => 
      _soundEffectFactory = soundEffectFactory;

    public void PlaySoundEffect() =>
      _soundEffectFactory.CreateSoundEffect(SoundEffectTypeId.BrickBroken);
  }
}