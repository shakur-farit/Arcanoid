using System.Collections.Generic;
using Code.Gameplay.Level.Service;
using Code.Gameplay.Loot.Behaviour;
using Code.Gameplay.ObjectPool.Service;

namespace Code.Gameplay.Loot.Service
{
  public class LootService : ILootService, ICleanable
  {
    private readonly List<LootItem> _loots = new();

    private readonly IObjectPoolService _objectPool;

    public LootService(IObjectPoolService objectPool) => 
      _objectPool = objectPool;

    public void SetLoot(LootItem loot) => 
	    _loots.Add(loot);

    public void RemoveLoot(LootItem loot)
    {
      _loots.Remove(loot);

      Destroy(loot);
		}

		public void Clean()
    {
      foreach (LootItem loot in _loots) 
	      Destroy(loot);

      _loots.Clear();
    }

    private void Destroy(LootItem loot) =>
      _objectPool.Return(loot.ViewPrefab, loot.gameObject);
  }
}