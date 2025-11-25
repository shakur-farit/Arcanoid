using Code.Gameplay.ObjectPool.Service;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class SoundEffectFactory : ISoundEffectFactory
  {
    private readonly IObjectPoolService _objectPool;
    private readonly IStaticDataService _staticDataService;

    public SoundEffectFactory(IObjectPoolService objectPool, IStaticDataService staticDataService)
    {
      _objectPool = objectPool;
      _staticDataService = staticDataService;
    }

    public void CreateSoundEffect(SoundEffectTypeId typeId)
    {
      SoundEffectConfig config = _staticDataService.GetSoundEffectConfig(typeId);

      SoundEffectItem item = _objectPool.Get<SoundEffectItem>(config.ViewPrefab, Vector3.zero);

      item.Initialize(config.ViewPrefab, config.AudioClip, config.Lifetime);
    }
  }
}