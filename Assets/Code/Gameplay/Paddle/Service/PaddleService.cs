using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class PaddleService : IPaddleService, ICleanable
  {
    private PaddleItem _paddle;

    public void SetPaddle(PaddleItem paddle) =>
      _paddle = paddle;

    public void Clean() =>
      Object.Destroy(_paddle.gameObject);
  }
}