using Code.Gameplay.Loot.Behaviour;
using Code.Gameplay.Loot.Config;
using Code.Gameplay.ObjectPool.Service;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Gameplay.Loot.Factory
	{
	  public class LootFactory : ILootFactory
	  {
      private readonly IObjectPoolService _objectPool;
      private readonly IStaticDataService _staticDataService;

	    public LootFactory(IObjectPoolService objectPool, IStaticDataService staticDataService)
	    {
        _objectPool = objectPool;
        _staticDataService = staticDataService;
	    }

	    public void CreateLoot(LootTypeId typeId, Vector2 at)
	    {
	      LootConfig config = _staticDataService.GetLootConfig(typeId);

	      LootItem item = _objectPool.Get<LootItem>(
	        config.ViewPrefab, at);

	      item.Initialize(config.ViewPrefab, typeId);
	    }
	  }
	}