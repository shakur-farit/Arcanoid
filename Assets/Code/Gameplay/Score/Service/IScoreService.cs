using System;

namespace Code.Gameplay.Score.Service
{
	public interface IScoreService
	{
		event Action ScoreChanged;
		int Score { get; }
		void IncreaseScore(int value);
    void ResetScore();
  }
}