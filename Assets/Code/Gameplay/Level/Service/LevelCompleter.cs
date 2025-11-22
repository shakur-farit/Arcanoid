using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;

namespace Code.Gameplay.Environment
{
	public class LevelCompleter : ILevelCompleter
	{
		private readonly IGameStateMachine _stateMachine;
		private readonly ILevelCleaner _levelCleaner;

		public LevelCompleter(IGameStateMachine stateMachine, ILevelCleaner levelCleaner)
		{
			_stateMachine = stateMachine;
			_levelCleaner = levelCleaner;
		}

		public void CompleteLevel()
		{
			_levelCleaner.CleanLevel();
			_stateMachine.Enter<LevelCompleteState>();
		}
	}
}