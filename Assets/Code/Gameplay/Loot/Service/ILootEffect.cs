namespace Code.Gameplay.Environment
{
  public interface ILootEffect
  {
    void Apply();
    LootTypeId TypeId { get; }
  }
}