using Code.Infrastructure.StaticData;
using Zenject;

namespace Code.Infrastructure.States.GameStates
{
  public class SoundEffectFactory : ISoundEffectFactory
  {
    private readonly IInstantiator _instantiator;
    private readonly IStaticDataService _staticDataService;

    public SoundEffectFactory(IInstantiator instantiator, IStaticDataService staticDataService)
    {
      _instantiator = instantiator;
      _staticDataService = staticDataService;
    }

    public void CreateSoundEffect(SoundEffectTypeId typeId)
    {
      SoundEffectConfig config = _staticDataService.GetSoundEffectConfig(typeId);

      SoundEffectItem item = _instantiator.InstantiatePrefabForComponent<SoundEffectItem>(config.ViewPrefab);

      item.Initialize(config.AudioClip, config.Lifetime);
    }
  }
}