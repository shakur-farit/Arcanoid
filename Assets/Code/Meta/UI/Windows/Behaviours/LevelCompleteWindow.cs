using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI.Windows.Service;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
  public class LevelCompleteWindow : BaseWindow
  {
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _quitButton;

		private IGameStateMachine _stateMachine;
    private IWindowService _windowService;
    private IQuitGameService _quitGame;

    [Inject]
    public void Constructor(
	    IGameStateMachine stateMachine, 
	    IWindowService windowService, 
	    IQuitGameService quitGame)
    {
      Id = WindowId.LevelCompleteWindow;

      _stateMachine = stateMachine;
      _windowService = windowService;
      _quitGame = quitGame;
    }

    protected override void SubscribeUpdates()
    {
      _nextButton.onClick.AddListener(EnterNextLevel);
      _quitButton.onClick.AddListener(QuitGame);
    }

    protected override void UnsubscribeUpdates()
    {
      _nextButton.onClick.RemoveAllListeners();
      _quitButton.onClick.RemoveAllListeners();
    }

    private void EnterNextLevel()
    {
      CloseWindow();
      EnterToLoadingGameplaySceneState();
    }

    private void EnterToLoadingGameplaySceneState() =>
      _stateMachine.Enter<LoadingGameplaySceneState, string>(Scenes.Gameplay);

    private void QuitGame()
    {
      CloseWindow();

      _quitGame.QuitGame();
    }

    private void CloseWindow() =>
      _windowService.Close(WindowId.LevelCompleteWindow);
  }
}