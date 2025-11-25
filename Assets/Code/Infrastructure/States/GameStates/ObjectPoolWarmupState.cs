using Code.Gameplay.ObjectPool.Service;
using Code.Infrastructure.States.Infrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
	public class ObjectPoolWarmupState : IState
	{
		private readonly IObjectPoolWarmupper _objectPoolWarmUpper;
		private readonly IGameStateMachine _stateMachine;

		public ObjectPoolWarmupState(IObjectPoolWarmupper objectPoolWarmUpper, IGameStateMachine stateMachine)
		{
			_objectPoolWarmUpper = objectPoolWarmUpper;
			_stateMachine = stateMachine;
		}

		public void Enter()
		{
			WarmupReusableObjects();
			EnterLoadingHomeScreenState();
		}

		public void Exit()
		{

		}

		private void WarmupReusableObjects() =>
			_objectPoolWarmUpper.WarmupObjects();

		private void EnterLoadingHomeScreenState() =>
			_stateMachine.Enter<LoadingHomeScreenSceneState>();
	}
}