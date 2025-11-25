using Code.Common.Extensions;
using Code.Gameplay.Loot.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Loot.Behaviour
{
  public class LootCollider : MonoBehaviour
  {
    [SerializeField] private LootItem _item;

    private ILootEffectService _lootEffectService;
    private ILootService _lootService;

    [Inject]
    public void Constructor(ILootEffectService lootEffectService, ILootService lootService)
    {
      _lootEffectService = lootEffectService;
      _lootService = lootService;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.MatchesCollisions(CollisionLayer.GameOverBorder.AsMask()))
        DestroyLoot();

      if (collision.MatchesCollisions(CollisionLayer.Paddle.AsMask()))
        CreateLootEffect();
    }

    private void CreateLootEffect()
    {
      _lootEffectService.CreateLootEffect(_item.TypeId);
      
      DestroyLoot();
    }

    private void DestroyLoot() => 
      _lootService.RemoveLoot(_item);
  }
}