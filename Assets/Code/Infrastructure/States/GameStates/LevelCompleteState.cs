using Code.Gameplay.Camera.Service;
using Code.Infrastructure.States.Infrastructure;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Service;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
	public class LevelCompleteState : IState
	{
    private readonly IWindowService _windowService;
    private readonly ICameraProvider _cameraProvider;

    public LevelCompleteState(IWindowService windowService, ICameraProvider cameraProvider)
    {
      _windowService = windowService;
      _cameraProvider = cameraProvider;
      _cameraProvider = cameraProvider;
    }

    public void Enter()
    {
	    _windowService.Close(WindowId.Hud);
			_windowService.Open(WindowId.LevelCompleteWindow);

      AudioSource audioSource = _cameraProvider.MainCamera.GetComponent<AudioSource>();
      audioSource.Stop();
    }

    public void Exit()
		{
		}
	}
}