using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Loot.Config;
using Code.Gameplay.Loot.Factory;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Gameplay.Loot.Service
{
  public class LootDropService : ILootDropService
  {
    private readonly IStaticDataService _staticDataService;
    private readonly ILootFactory _lootFactory;

    public LootDropService(IStaticDataService staticDataService, ILootFactory lootFactory)
    {
      _staticDataService = staticDataService;
      _lootFactory = lootFactory;
    }

    public void DropLoot(IEnumerable<LootTypeId> excludedLoot, Vector2 at)
    {
      LootTypeId? loot = GetRandomLoot(excludedLoot);

      if (loot == null)
        return;

      _lootFactory.CreateLoot((LootTypeId)loot, at);
    }

    private LootTypeId? GetRandomLoot(IEnumerable<LootTypeId> excludedLoot)
    {
      IEnumerable<LootTypeId> allLootTypes = System.Enum
        .GetValues(typeof(LootTypeId))
        .Cast<LootTypeId>()
        .Where(t => t != LootTypeId.Unknown);

      if (excludedLoot != null)
        allLootTypes = allLootTypes.Where(t => excludedLoot.Contains(t) == false);

      List<LootConfig> configs = allLootTypes
        .Select(t => _staticDataService.GetLootConfig(t))
        .ToList();

      if (configs.Count == 0)
        return null;

      float dropChance = configs.Max(c => c.DropChance);

      if (Random.Range(0f, 100f) > dropChance)
        return null;

      List<LootConfig> weighted = configs
        .Where(c => c.DropWeight > 0)
        .ToList();

      if (weighted.Count == 0)
        return null;

      float totalWeight = weighted.Sum(c => c.DropWeight);
      float roll = Random.Range(0f, totalWeight);
      float current = 0f;

      foreach (LootConfig config in weighted)
      {
        current += config.DropWeight;
        if (roll <= current)
          return config.TypeId;
      }

      return null;
    }
  }
}