using Code.Infrastructure.StaticData;

namespace Code.Gameplay.Environment
{
	public class LevelProgressService : ILevelProgressService
	{
		private readonly IBallMovementSpeedService _ballMovementSpeedService;
		private readonly IStaticDataService _staticDataService;

		public LevelProgressService(
			IBallMovementSpeedService ballMovementSpeedService,
			IStaticDataService staticDataService)
		{
			_ballMovementSpeedService = ballMovementSpeedService;
			_staticDataService = staticDataService;
		}

		public void ProgressLevel() => 
			IncreaseBallMovementSpeed();

		private void IncreaseBallMovementSpeed()
		{
			LevelConfig config = _staticDataService.GetLevelConfig();

			_ballMovementSpeedService.IncreaseMovementSpeed(config.BallMovementSpeedIncreaseValue);
		}
	}
}