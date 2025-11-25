using UnityEngine;

namespace Code.Gameplay.Loot.Config
{
  [CreateAssetMenu(menuName = "Arcanoid/Loot Config", fileName = "LootConfig")]
  public class LootConfig : ScriptableObject
  {
    public LootTypeId TypeId;
    public GameObject ViewPrefab;
    public int DropChance;
    public int DropWeight;
  }
}