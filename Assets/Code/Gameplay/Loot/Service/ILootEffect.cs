namespace Code.Gameplay.Loot.Service
{
  public interface ILootEffect
  {
    void Apply();
    LootTypeId TypeId { get; }
  }
}