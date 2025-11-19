using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.StaticData;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.GameStates
{
	public class LoadStaticDataState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly IStaticDataService _staticDataService;

		public LoadStaticDataState(IGameStateMachine gameStateMachine, IStaticDataService staticDataService)
		{
			_gameStateMachine = gameStateMachine;
			_staticDataService = staticDataService;
		}

		public async void Enter()
    {
      await LoadStaticData();

      EnterToLoadingHomeScreenSceneState();
    }

    public void Exit()
		{
			
		}

    private async UniTask LoadStaticData() => 
      await _staticDataService.LoadAll();

    private void EnterToLoadingHomeScreenSceneState() => 
      _gameStateMachine.Enter<LoadingHomeScreenSceneState>();
  }
}