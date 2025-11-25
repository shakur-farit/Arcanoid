using Code.Gameplay.Loot.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Loot.Behaviour
{
  public class LootItem : MonoBehaviour
  {
	  private ILootService _lootService;
	  public GameObject ViewPrefab { get; private set; }
	  public LootTypeId TypeId { get; private set; }

    [Inject]
    public void Constructor(ILootService lootService) => 
	    _lootService = lootService;

    public void Initialize(GameObject viewPrefab, LootTypeId typeId)
    {
      ViewPrefab = viewPrefab;
	    TypeId = typeId;

      _lootService.SetLoot(this);
    }
  }
}