using Code.Gameplay.Level.Service;
using Code.Gameplay.ObjectPool.Service;
using Code.Gameplay.Paddle.Behaviour;

namespace Code.Gameplay.Paddle.Service
{
  public class PaddleService : IPaddleService, ICleanable
  {
    private PaddleItem _paddle;

    private readonly IObjectPoolService _objectPool;

    public PaddleService(IObjectPoolService objectPool) => 
      _objectPool = objectPool;

    public void SetPaddle(PaddleItem paddle) =>
      _paddle = paddle;

    public void Clean() =>
      _objectPool.Return(_paddle.ViewPrefab, _paddle.gameObject);
  }
}