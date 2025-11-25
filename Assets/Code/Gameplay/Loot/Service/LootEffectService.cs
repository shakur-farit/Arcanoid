using System;
using System.Collections.Generic;

namespace Code.Gameplay.Loot.Service
{
  public class LootEffectService : ILootEffectService
  {
    private readonly Dictionary<LootTypeId, ILootEffect> _effects;

    public LootEffectService(List<ILootEffect> effects)
    {
      _effects = new Dictionary<LootTypeId, ILootEffect>();

      foreach (ILootEffect effect in effects)
        _effects.Add(effect.TypeId, effect);
    }

    public void CreateLootEffect(LootTypeId typeId)
    {
      if (_effects.TryGetValue(typeId, out ILootEffect effect))
        effect.Apply();
      else
        throw new Exception($"No effect registered for {typeId}");
    }
  }
}