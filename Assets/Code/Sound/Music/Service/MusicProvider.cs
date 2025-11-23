using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class MusicProvider : IAudioSourceSetter, IMusicPlayer
  {
    private AudioSource _audioSource;
    private MusicConfig _currentMusicConfig;

    private readonly IStaticDataService _staticDataService;

    public MusicProvider(IStaticDataService staticDataService) => 
      _staticDataService = staticDataService;

    public void SetAudioSource(AudioSource audioSource) =>
      _audioSource = audioSource;

    public void PlayMusic(MusicTypeId typeId)
    {
      _audioSource.Stop();

      _currentMusicConfig = _staticDataService.GetMusicConfig(typeId);

      _audioSource.clip = _currentMusicConfig.AudioClip;
      _audioSource.volume = _currentMusicConfig.Volume;
      _audioSource.loop = _currentMusicConfig.Loop;

      _audioSource.Play();
    }
  }
}