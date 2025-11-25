using Code.Infrastructure.StaticData;

namespace Code.Gameplay.Environment
{
	public class ObjectPoolWarmupper : IObjectPoolWarmupper
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IObjectPoolService _objectPool;

		public ObjectPoolWarmupper(IStaticDataService staticDataService, IObjectPoolService objectPool)
		{
			_staticDataService = staticDataService;
			_objectPool = objectPool;
		}

		public void WarmupObjects()
		{
			ObjectPoolConfig config = _staticDataService.GetObjectPoolConfig();

			foreach (WarmupObject prefabToWarm in config.WarmupObjects)
				_objectPool.WarmUp(prefabToWarm.ViewPrefab, prefabToWarm.Count);
		}
	}
}