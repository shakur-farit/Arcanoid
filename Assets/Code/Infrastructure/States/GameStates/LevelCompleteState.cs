using Code.Infrastructure.States.Infrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;

namespace Code.Infrastructure.States.GameStates
{
	public class LevelCompleteState : IState
	{
    private readonly IWindowService _windowService;
    private readonly IMusicPlayer _musicPlayer;

    public LevelCompleteState(IWindowService windowService, IMusicPlayer musicPlayer)
    {
	    _windowService = windowService;
	    _musicPlayer = musicPlayer;
    }

    public void Enter()
    {
	    OpenLevelCompleteWindow();
	    PlayLevelCompleteMusic();
    }

    public void Exit()
		{
		}

    private void OpenLevelCompleteWindow() => 
	    _windowService.Open(WindowId.LevelCompleteWindow);

    private void PlayLevelCompleteMusic() => 
	    _musicPlayer.PlayMusic(MusicTypeId.LevelCompleteMusic);
	}
}