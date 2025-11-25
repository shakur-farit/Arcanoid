using System.Collections.Generic;
using Code.Gameplay.Loot;
using Code.Gameplay.Loot.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Brick.Behaviour
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