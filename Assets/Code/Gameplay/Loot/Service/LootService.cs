using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class LootService : ILootService, IRemovable
  {
    private readonly List<LootItem> _loots = new();

    public void SetLoot(LootItem loot) => 
      _loots.Add(loot);

    public void RemoveLoot(LootItem loot)
    {
      _loots.Remove(loot);

      Destroy(loot);
    }

    public void Remove()
    {
      foreach (LootItem loot in _loots) 
        Destroy(loot);

      _loots.Clear();
    }

    private void Destroy(LootItem loot) => 
      Object.Destroy(loot.gameObject);
  }
}