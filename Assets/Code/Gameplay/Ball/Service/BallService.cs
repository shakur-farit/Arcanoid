using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class BallService : IBallService, IRemovable
	{
		private BallItem _ball;

		public void SetBall(BallItem ball) => 
			_ball = ball;

		public void Remove() => 
			Object.Destroy(_ball.gameObject);
	}
}