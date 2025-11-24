using System;
using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class ExtraBallEffect : ILootEffect
  {
    private readonly IBallFactory _ballFactory;

    public LootTypeId TypeId => LootTypeId.ExtraBall;

    public ExtraBallEffect(IBallFactory ballFactory) =>
      _ballFactory = ballFactory;

    public void Apply() =>
      _ballFactory.CreateBall();
  }
}