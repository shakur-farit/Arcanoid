using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class SoundEffectItem : MonoBehaviour
  {
    [SerializeField] private SoundEffectPlayer _player;
    [SerializeField] private SoundEffectDestructor _destructor;

    public GameObject ViewPrefab { get; private set; }

    public async void Initialize(GameObject viewPrefab, AudioClip audioClip, int lifetime)
    {
      ViewPrefab = viewPrefab;

      _player.PlaySoundEffect(audioClip);
      
      await _destructor.Destruct(lifetime);
    }
  }
}