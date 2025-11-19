using Code.Infrastructure.AssetsProvider;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.States.StateMachine;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.GameStates
{
	public class BootstrapState : IState
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly IAssetProvider _assetProvider;

		public BootstrapState(
			IGameStateMachine stateMachine, 
			IAssetProvider assetProvider)
		{
			_stateMachine = stateMachine;
			_assetProvider = assetProvider;
		}

		public async void Enter()
    {
      await InitializeAddressables();

      EnterToLoadStaticDataState();
    }

    public void Exit()
		{
		}

    private async UniTask InitializeAddressables() => 
      await _assetProvider.Initialize();

    private void EnterToLoadStaticDataState() => 
      _stateMachine.Enter<LoadStaticDataState>();
  }
}