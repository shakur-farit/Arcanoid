using System;

namespace Code.Gameplay.Environment
{
	public interface IScoreService
	{
		event Action ScoreChanged;
		int Score { get; }
		void IncreaseScore(int value);
    void ResetScore();
  }
}