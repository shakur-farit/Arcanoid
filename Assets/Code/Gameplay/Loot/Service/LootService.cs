using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class LootService : ILootService, ICleanable
  {
    private readonly List<LootItem> _loots = new();

    public void SetLoot(LootItem loot) => 
	    _loots.Add(loot);

    public void RemoveLoot(LootItem loot)
    {
      _loots.Remove(loot);

      Destroy(loot);
		}

		public void Clean()
    {
      Debug.Log($"{_loots.Count} - on level end");

      foreach (LootItem loot in _loots) 
	      Destroy(loot);

      _loots.Clear();

      Debug.Log($"{_loots.Count} - after remove");
		}

		private void Destroy(LootItem loot) => 
      Object.Destroy(loot.gameObject);
  }
}