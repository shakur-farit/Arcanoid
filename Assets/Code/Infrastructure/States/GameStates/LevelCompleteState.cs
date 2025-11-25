using Code.Gameplay.Environment;
using Code.Infrastructure.States.Infrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;

namespace Code.Infrastructure.States.GameStates
{
	public class LevelCompleteState : IState
	{
    private readonly IWindowService _windowService;
    private readonly IMusicPlayer _musicPlayer;
    private readonly ILevelProgressService _progressService;

    public LevelCompleteState(
	    IWindowService windowService, 
	    IMusicPlayer musicPlayer, 
	    ILevelProgressService progressService)
    {
	    _windowService = windowService;
	    _musicPlayer = musicPlayer;
	    _progressService = progressService;
    }

    public void Enter()
    {
	    ProgressLevel();
	    OpenLevelCompleteWindow();
	    PlayLevelCompleteMusic();
    }

    public void Exit()
		{
		}
    
		private void ProgressLevel() => 
	    _progressService.ProgressLevel();

    private void OpenLevelCompleteWindow() => 
	    _windowService.Open(WindowId.LevelCompleteWindow);

    private void PlayLevelCompleteMusic() => 
	    _musicPlayer.PlayMusic(MusicTypeId.LevelCompleteMusic);
	}
}