using System.Collections.Generic;
using Code.Gameplay.Ball.Behaviour;

namespace Code.Gameplay.Ball.Service
{
	public interface IBallService
	{
		void SetBall(BallItem ball);
		List<BallItem> GetBalls();
		void RemoveBall(BallItem ball);
	}
}