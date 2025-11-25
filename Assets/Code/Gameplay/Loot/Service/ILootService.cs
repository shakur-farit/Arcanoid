using Code.Gameplay.Loot.Behaviour;

namespace Code.Gameplay.Loot.Service
{
  public interface ILootService
  {
    void SetLoot(LootItem loot);
    void RemoveLoot(LootItem loot);
  }
}