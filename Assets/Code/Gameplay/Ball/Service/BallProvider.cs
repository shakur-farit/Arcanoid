using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class BallProvider : IBallProvider
	{
		private BallItem _ball;

		public void SetBall(BallItem ball) => 
			_ball = ball;

		public void RemoveBall() => 
			Object.Destroy(_ball.gameObject);
	}
}