using UnityEngine;

namespace Code.Infrastructure.Loading
{
  public class QuitGameService : IQuitGameService
  {
    public void QuitGame()
    {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
  }
}