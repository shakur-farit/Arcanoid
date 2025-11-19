using Code.Infrastructure.States.GameStates;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class AudioSourceInitializer : MonoBehaviour, IInitializable
  {
    public AudioSource AudioSource;

    private IAudioSourceSetter _audioSourceSetter;

    [Inject]
    public void Constructor(IAudioSourceSetter audioSourceSetter) =>
      _audioSourceSetter = audioSourceSetter;

    public void Initialize() =>
      _audioSourceSetter.SetAudioSource(AudioSource);
  }
}