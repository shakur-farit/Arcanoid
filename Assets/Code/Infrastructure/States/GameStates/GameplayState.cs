using Code.Gameplay.Environment;
using Code.Infrastructure.States.Infrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;

namespace Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
		private readonly IWindowService _windowService;
    private readonly ILevelBuilder _levelBuilder;

    public GameplayState(IWindowService windowService, ILevelBuilder levelBuilder)
    {
      _windowService = windowService;
      _levelBuilder = levelBuilder;
    }

		public void Enter()
		{
			OpenHudWindow();
			CreateLevel();
		}

		public void Exit()
		{
		}

		private void OpenHudWindow() => 
			_windowService.Open(WindowId.Hud);

		
		private void CreateLevel() => 
			_levelBuilder.CreateLevel();
	}
}