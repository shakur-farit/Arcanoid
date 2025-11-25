using Code.Gameplay.Ball.Factory;

namespace Code.Gameplay.Loot.Service
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