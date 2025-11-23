using Code.Infrastructure.States.Infrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;

namespace Code.Infrastructure.States.GameStates
{
	public class HomeScreenState : IState
	{
		private readonly IWindowService _windowService;
    private readonly IMusicPlayer _musicPlayer;

    public HomeScreenState(IWindowService windowService, IMusicPlayer musicPlayer)
    {
      _windowService = windowService;
      _musicPlayer = musicPlayer;
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
      _musicPlayer.PlayMusic(MusicTypeId.MainMenuMusic);
  }
}