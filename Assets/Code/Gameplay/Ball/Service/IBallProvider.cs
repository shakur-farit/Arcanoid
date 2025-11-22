namespace Code.Gameplay.Environment
{
	public interface IBallProvider
	{
		void SetBall(BallItem ball);
		void RemoveBall();
	}
}