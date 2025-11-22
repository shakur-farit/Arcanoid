using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class PaddleService : IPaddleService, IRemovable
  {
    private PaddleItem _paddle;

    public void SetPaddle(PaddleItem paddle) =>
      _paddle = paddle;

    public void Remove() =>
      Object.Destroy(_paddle.gameObject);
  }
}