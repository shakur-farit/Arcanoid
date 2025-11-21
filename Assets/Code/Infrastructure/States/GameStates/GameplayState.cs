using Code.Gameplay.Environment;
using Code.Infrastructure.States.Infrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;

namespace Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
		private readonly IWindowService _windowService;
		private readonly IEnvironmentFactory _environmentFactory;
		private readonly IPaddleFactory _paddleFactory;
		private readonly ILevelBuilder _levelBuilder;

    public GameplayState(
	    IWindowService windowService, 
	    IEnvironmentFactory environmentFactory, 
	    IPaddleFactory paddleFactory, 
	    ILevelBuilder levelBuilder)
    {
      _windowService = windowService;
      _environmentFactory = environmentFactory;
      _paddleFactory = paddleFactory;
      _levelBuilder = levelBuilder;
    }

		public void Enter()
		{
			OpenHudWindow();

			CreateEnvironment();

			CreateLevel();

			CreatePaddle();
		}

		public void Exit()
		{
		}

		private void OpenHudWindow() => 
			_windowService.Open(WindowId.Hud);

		private void CreateEnvironment() => 
			_environmentFactory.CreateEnvironment();

		private void CreateLevel() => 
			_levelBuilder.CreateLevel();

		private void CreatePaddle() => 
			_paddleFactory.CreatePaddle();
	}
}