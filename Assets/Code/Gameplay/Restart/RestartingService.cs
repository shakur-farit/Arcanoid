using System;

namespace Code.Gameplay.Restart
{
  public class RestartingService : IRestartingService
  {
	  public event Action Restarted;

    public void Restart()
	  {
      Restarted?.Invoke();
	  }
  }
}