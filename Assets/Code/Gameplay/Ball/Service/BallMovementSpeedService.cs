namespace Code.Gameplay.Environment
{
	public class BallMovementSpeedService : IBallMovementSpeedService
	{
		private float _speed;

		public float GetMovementSpeed(float baseSpeed) => 
			_speed + baseSpeed;

		public void IncreaseMovementSpeed(float value) => 
			_speed += value;

		public void DecreaseMovementSpeed(float value) => 
			_speed -= value;

		public void ResetSpeed() => 
			_speed = 0;
	}
}