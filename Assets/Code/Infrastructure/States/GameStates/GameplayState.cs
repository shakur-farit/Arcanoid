using Code.Gameplay.Level.Service;
using Code.Infrastructure.States.Infrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;

namespace Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
		private readonly IWindowService _windowService;
		private readonly ILevelActiveObjectGenerator _levelActiveObjectGenerator;
		private readonly ILevelBuilder _levelBuilder;
		private readonly ILevelCleaner _levelCleaner;
		private readonly IMusicPlayer _musicPlayer;

		public GameplayState(
	    IWindowService windowService, 
	    ILevelActiveObjectGenerator levelActiveObjectGenerator, 
	    ILevelBuilder levelBuilder,
	    ILevelCleaner levelCleaner,
	    IMusicPlayer musicPlayer)
    {
      _windowService = windowService;
      _levelActiveObjectGenerator = levelActiveObjectGenerator;
      _levelBuilder = levelBuilder;
      _levelCleaner = levelCleaner;
      _musicPlayer = musicPlayer;
    }

		public void Enter()
		{
			OpenHudWindow();
			CreateLevel();
			CreateActiveObjects();
			PlayGameplayMusic();
    }

		public void Exit()
		{
			CloseHudWindow();
			CleanLevel();
		}

		private void OpenHudWindow() => 
			_windowService.Open(WindowId.Hud);

		private void CloseHudWindow() =>
      _windowService.Close(WindowId.Hud);

		private void CreateLevel() => 
			_levelBuilder.CreateLevel();

		private void CreateActiveObjects() => 
			_levelActiveObjectGenerator.Generate();

		private void PlayGameplayMusic() => 
			_musicPlayer.PlayMusic(MusicTypeId.GameplayMusic);

		private void CleanLevel() => 
			_levelCleaner.CleanLevel();
	}
}