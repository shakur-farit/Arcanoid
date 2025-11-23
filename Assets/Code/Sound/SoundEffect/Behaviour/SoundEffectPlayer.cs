using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class SoundEffectPlayer : MonoBehaviour
  {
    [SerializeField] private AudioSource _audioSource;

    public void PlaySoundEffect(AudioClip audioClip)
    {
      _audioSource.clip = audioClip;

      _audioSource.Play();
    }
  }
}