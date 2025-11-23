using Code.Infrastructure.Loading;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Meta.UI.Windows.Service;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
  public class MainMenuWindow : BaseWindow
  {
    [SerializeField] private Button _startGameButton;
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
      Id = WindowId.MainMenuWindow;

      _stateMachine = stateMachine;
      _windowService = windowService;
      _quitGame = quitGame;
    }

    protected override void SubscribeUpdates()
    {
      _startGameButton.onClick.AddListener(EnterGame);
      _startGameButton.onClick.AddListener(CloseWindow);

      _quitButton.onClick.AddListener(QuitGame);
    }

    protected override void UnsubscribeUpdates()
    {
      _startGameButton.onClick.RemoveAllListeners();
      _quitButton.onClick.RemoveAllListeners();
    }

    private void EnterGame() =>
      _stateMachine.Enter<LoadingGameplaySceneState, string>(Scenes.Gameplay);

    private void QuitGame()
    {
      CloseWindow();

      _quitGame.QuitGame();
    }

    private void CloseWindow() =>
      _windowService.Close(WindowId.MainMenuWindow);
  }
}