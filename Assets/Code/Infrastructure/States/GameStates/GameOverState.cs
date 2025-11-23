using Code.Infrastructure.States.Infrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;

namespace Code.Infrastructure.States.GameStates
{
	public class GameOverState : IState
	{
    private readonly IWindowService _windowService;
    private readonly IMusicPlayer _musicPlayer;

    public GameOverState(IWindowService windowService, IMusicPlayer musicPlayer)
    {
	    _windowService = windowService;
	    _musicPlayer = musicPlayer;
    }

    public void Enter()
    {
	    OpenGameOverWindow();
	    PlayGameOverMusic();
    }

    public void Exit()
		{
		}

    private void OpenGameOverWindow() => 
	    _windowService.Open(WindowId.GameOverWindow);

    private void PlayGameOverMusic() => 
	    _musicPlayer.PlayMusic(MusicTypeId.GameOverMusic);
	}
}