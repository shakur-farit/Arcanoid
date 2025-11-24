using UnityEngine;

namespace Code.Gameplay.Environment
{
  public interface ILootFactory
  {
    void CreateLoot(LootTypeId typeId, Vector2 at);
  }
}