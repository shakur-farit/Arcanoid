using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class SoundEffectItem : MonoBehaviour
  {
    [SerializeField] private SoundEffectPlayer _player;
    [SerializeField] private SoundEffectDestructor _destructor;

    public async void Initialize(AudioClip audioClip, int lifetime)
    {
      _player.PlaySoundEffect(audioClip);
      await _destructor.Destruct(lifetime);
    }
  }
}