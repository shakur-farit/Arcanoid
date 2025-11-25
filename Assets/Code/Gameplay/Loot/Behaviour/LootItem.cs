using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class LootItem : MonoBehaviour
  {
	  private ILootService _lootService;
	  public LootTypeId TypeId { get; private set; }

    [Inject]
    public void Constructor(ILootService lootService) => 
	    _lootService = lootService;

    public void Initialize(LootTypeId typeId)
    {
	    TypeId = typeId;

      _lootService.SetLoot(this);
    }
  }
}