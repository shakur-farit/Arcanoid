using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;
using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class LevelCleaner : ILevelCleaner
	{
		private readonly IBrickProvider _brickProvider;
		private readonly IBallProvider _ballProvider;
		private readonly IWindowService _windowService;

		public LevelCleaner(
			IBrickProvider brickProvider,
			IBallProvider ballProvider,
			IWindowService windowService)
		{
			_brickProvider = brickProvider;
			_ballProvider = ballProvider;
			_windowService = windowService;
		}

		public void CleanLevel()
		{
			RemoveBricks();
			RemovePaddle();
			RemoveBall();
			RemoveEnvironment();
			CloseHud();
		}

		private void RemoveEnvironment()
		{
			
		}

		private void RemoveBall() => 
			_ballProvider.RemoveBall();

		private void RemovePaddle()
		{
			
		}

		private void RemoveBricks()
		{
			foreach (BrickItem brick in _brickProvider.GetBricks()) 
				_brickProvider.RemoveBrick(brick);
		}

		private void CloseHud() => 
			_windowService.Close(WindowId.Hud);
	}
}