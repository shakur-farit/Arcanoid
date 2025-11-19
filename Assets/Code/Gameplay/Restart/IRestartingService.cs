using System;

namespace Code.Gameplay.Restart
{
  public interface IRestartingService
  {
    event Action Restarted;
    void Restart();
  }
}