	using Code.Infrastructure.StaticData;
	using UnityEngine;
	using Zenject;

	namespace Code.Gameplay.Environment
	{
	  public class LootFactory : ILootFactory
	  {
	    private readonly IInstantiator _instantiator;
	    private readonly IStaticDataService _staticDataService;

	    public LootFactory(IInstantiator instantiator, IStaticDataService staticDataService)
	    {
	      _instantiator = instantiator;
	      _staticDataService = staticDataService;
	    }

	    public void CreateLoot(LootTypeId typeId, Vector2 at)
	    {
	      LootConfig config = _staticDataService.GetLootConfig(typeId);

	      LootItem item = _instantiator.InstantiatePrefabForComponent<LootItem>(
	        config.ViewPrefab, at, Quaternion.identity, null);

	      item.Initialize(typeId);
	    }
	  }
	}