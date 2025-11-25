using System;

namespace Code.Gameplay.Score.Service
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

    public void ResetScore() => 
			Score = 0;
	}
}