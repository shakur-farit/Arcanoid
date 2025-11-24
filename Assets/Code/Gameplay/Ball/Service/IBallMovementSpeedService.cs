namespace Code.Gameplay.Environment
{
	public interface IBallMovementSpeedService
	{
		float GetMovementSpeed(float baseSpeed);
		void IncreaseMovementSpeed(float value);
		void DecreaseMovementSpeed(float value);
		void ResetSpeed();
	}
}