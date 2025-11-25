using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class BallService : IBallService, ICleanable
	{
		private readonly List<BallItem> _balls = new();

		public void SetBall(BallItem ball) => 
			_balls.Add(ball);

		public List<BallItem> GetBalls() => 
			_balls;

		public void RemoveBall(BallItem ball)
		{
			_balls.Remove(ball);

			Destroy(ball);
		}

		public void Clean()
		{
			foreach (BallItem ball in _balls) 
				Destroy(ball);

			_balls.Clear();
		}

		private void Destroy(BallItem ball) => 
			Object.Destroy(ball.gameObject);
	}
}