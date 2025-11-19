using Code.Gameplay.Environment;
using Code.Infrastructure.States.Infrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;

namespace Code.Infrastructure.States.GameStates
{
	public class GameplayState : IState
	{
		private readonly IWindowService _windowService;
    private readonly IGridFactory _gridFactory;

    public GameplayState(IWindowService windowService, IGridFactory gridFactory)
    {
      _windowService = windowService;
      _gridFactory = gridFactory;
    }

		public void Enter()
		{
			OpenHudWindow();
      _gridFactory.CreateGrid();
    }

    public void Exit()
		{
		}

    private void OpenHudWindow() => 
      _windowService.Open(WindowId.Hud);
  }
}