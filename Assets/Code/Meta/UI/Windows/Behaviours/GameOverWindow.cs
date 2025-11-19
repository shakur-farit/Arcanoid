using Code.Gameplay.Restart;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI.Windows.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
  public class GameOverWindow : BaseWindow
  {
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private IGameStateMachine _stateMachine;
    private IWindowService _windowService;
    private IRestartingService _restarting;

    [Inject]
    public void Constructor(
	    IGameStateMachine stateMachine, 
	    IWindowService windowService, 
	    IRestartingService restarting)
    {
      Id = WindowId.GameOverWindow;

      _stateMachine = stateMachine;
      _windowService = windowService;
      _restarting = restarting;
    }

    protected override void Initialize()
    {
      _restartButton.onClick.AddListener(EnterToBattle);
      _quitButton.onClick.AddListener(QuitGame);
    }

    private void EnterToBattle()
    {
      CloseWindow();
      _restarting.Restart();
      _stateMachine.Enter<LoadingGameplaySceneState, string>(Scenes.Gameplay);
    }

    private void QuitGame()
    {
      CloseWindow();

#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    private void CloseWindow() =>
      _windowService.Close(WindowId.GameOverWindow);
  }
}