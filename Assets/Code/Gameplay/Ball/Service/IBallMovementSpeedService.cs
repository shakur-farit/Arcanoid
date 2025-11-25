namespace Code.Gameplay.Ball.Service
{
	public interface IBallMovementSpeedService
	{
		float GetMovementSpeed(float baseSpeed);
		void IncreaseMovementSpeed(float value);
		void DecreaseMovementSpeed(float value);
		void ResetSpeed();
	}
}