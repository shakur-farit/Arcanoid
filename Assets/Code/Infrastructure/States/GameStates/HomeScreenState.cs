using Code.Infrastructure.States.Infrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;

namespace Code.Infrastructure.States.GameStates
{
	public class HomeScreenState : IState
	{
		private readonly IWindowService _windowService;
    private readonly IMusicClipSetter _musicClipSetter;

    public HomeScreenState(IWindowService windowService, IMusicClipSetter musicClipSetter)
    {
      _windowService = windowService;
      _musicClipSetter = musicClipSetter;
    }

    public void Enter()
    {
      OpenMainMenuWindow();

      PlayMainMenuMusic();
    }

    public void Exit()
		{
		}

    private void OpenMainMenuWindow() => 
      _windowService.Open(WindowId.MainMenuWindow);

    private void PlayMainMenuMusic() => 
      _musicClipSetter.SetClip(MusicTypeId.MainMenuMusic);
  }
}