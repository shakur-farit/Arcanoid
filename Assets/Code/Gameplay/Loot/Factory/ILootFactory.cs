using UnityEngine;

namespace Code.Gameplay.Loot.Factory
{
  public interface ILootFactory
  {
    void CreateLoot(LootTypeId typeId, Vector2 at);
  }
}