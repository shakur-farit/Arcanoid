using Code.Gameplay.Restart;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI.Windows.Service;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
  public class GameOverWindow : BaseWindow
  {
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;

    private IGameStateMachine _stateMachine;
    private IWindowService _windowService;
    private IRestartingService _restarting;
    private IQuitGameService _quitGame;

    [Inject]
    public void Constructor(
	    IGameStateMachine stateMachine, 
	    IWindowService windowService, 
	    IQuitGameService quitGame, 
	    IRestartingService restarting)
    {
      Id = WindowId.GameOverWindow;

      _stateMachine = stateMachine;
      _windowService = windowService;
      _restarting = restarting;
      _quitGame = quitGame;
    }

    protected override void SubscribeUpdates()
    {
      _restartButton.onClick.AddListener(EnterGame);
      _quitButton.onClick.AddListener(QuitGame);
    }

    protected override void UnsubscribeUpdates()
    {
      _restartButton.onClick.RemoveAllListeners();
      _quitButton.onClick.RemoveAllListeners();
    }

    private void EnterGame()
    {
      CloseWindow();
      RestartGame();
      EnterToLoadingGameplaySceneState();
    }

    private void RestartGame() => 
      _restarting.Restart();

    private void EnterToLoadingGameplaySceneState() => 
      _stateMachine.Enter<LoadingGameplaySceneState, string>(Scenes.Gameplay);

    private void QuitGame()
    {
      CloseWindow();

      _quitGame.QuitGame();
    }

    private void CloseWindow() =>
      _windowService.Close(WindowId.GameOverWindow);
  }
}