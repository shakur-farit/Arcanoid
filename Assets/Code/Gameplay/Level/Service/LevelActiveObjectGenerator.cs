namespace Code.Gameplay.Environment
{
	public class LevelActiveObjectGenerator : ILevelActiveObjectGenerator
	{
		private readonly IPaddleFactory _paddleFactory;
		private readonly IBallFactory _ballFactory;

		public LevelActiveObjectGenerator(IPaddleFactory paddleFactory, IBallFactory ballFactory)
		{
			_paddleFactory = paddleFactory;
			_ballFactory = ballFactory;
		}

		public void Generate()
		{
			CreatePaddle();
			CreateBall();
		}

		private void CreateBall() => 
			_ballFactory.CreateBall();

		private void CreatePaddle() => 
			_paddleFactory.CreatePaddle();
	}
}