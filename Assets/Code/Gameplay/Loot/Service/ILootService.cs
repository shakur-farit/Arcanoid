namespace Code.Gameplay.Environment
{
  public interface ILootService
  {
    void SetLoot(LootItem loot);
    void RemoveLoot(LootItem loot);
  }
}