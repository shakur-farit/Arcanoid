using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
  public interface ILootDropService
  {
    void DropLoot(IEnumerable<LootTypeId> excludedLoot, Vector2 at);
  }
}