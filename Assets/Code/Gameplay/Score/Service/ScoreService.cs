using System;

namespace Code.Gameplay.Environment
{
	public class ScoreService : IScoreService
	{
		public event Action ScoreChanged;

		public int Score { get; private set; }

		public void IncreaseScore(int value)
		{
			Score += value;

			ScoreChanged?.Invoke();
		}

    public void RestartScore() => 
			Score = 0;
	}
}