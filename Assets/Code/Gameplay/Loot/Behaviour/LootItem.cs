using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.Environment
{
  public class LootItem : MonoBehaviour
  {
    public LootTypeId TypeId { get; private set; }

    public void Initialize(LootTypeId typeId) => 
      TypeId = typeId;
  }
}