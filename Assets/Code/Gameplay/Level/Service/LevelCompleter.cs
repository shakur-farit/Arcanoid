using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;

namespace Code.Gameplay.Level.Service
{
	public class LevelCompleter : ILevelCompleter
	{
		private readonly IGameStateMachine _stateMachine;

		public LevelCompleter(IGameStateMachine stateMachine) => 
			_stateMachine = stateMachine;

		public void CompleteLevel() => 
			_stateMachine.Enter<LevelCompleteState>();
	}
}