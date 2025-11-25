using System.Collections.Generic;
using Code.Gameplay.Ball.Behaviour;
using Code.Gameplay.Level.Service;
using Code.Gameplay.ObjectPool.Service;

namespace Code.Gameplay.Ball.Service
{
	public class BallService : IBallService, ICleanable
	{
    private readonly List<BallItem> _balls = new();

    private readonly IObjectPoolService _objectPool;

    public BallService(IObjectPoolService objectPool) => 
			_objectPool = objectPool;

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
			_objectPool.Return(ball.ViewPrefab, ball.gameObject);
	}
}