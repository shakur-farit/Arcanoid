using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class BrickLootDropper : MonoBehaviour
  {
    private ILootDropService _lootDropService;

    [Inject]
    public void Constructor(ILootDropService lootDropService) => 
      _lootDropService = lootDropService;

    public void DropLoot(IEnumerable<LootTypeId> excludedLoot, Vector2 at) => 
      _lootDropService.DropLoot(excludedLoot,at);
  }
}