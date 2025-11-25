using System.Collections.Generic;

namespace Code.Gameplay.Environment
{
	public interface IBallService
	{
		void SetBall(BallItem ball);
		List<BallItem> GetBalls();
		void RemoveBall(BallItem ball);
	}
}