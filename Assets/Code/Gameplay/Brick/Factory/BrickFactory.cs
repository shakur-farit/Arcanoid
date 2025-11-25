using Code.Gameplay.Brick.Behaviour;
using Code.Gameplay.Brick.Config;
using Code.Gameplay.Grid.Service;
using Code.Gameplay.ObjectPool.Service;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Gameplay.Brick.Factory
{
	public class BrickFactory : IBrickFactory
	{
    private readonly IObjectPoolService _objectPool;
    private readonly IStaticDataService _staticDataService;

		public BrickFactory(IObjectPoolService objectPool, IStaticDataService staticDataService)
		{
      _objectPool = objectPool;
      _staticDataService = staticDataService;
		}

		public void CreateBrick(Vector2 at, GridData gridData)
		{
			BrickConfig config = _staticDataService.GetBrickConfig();

      BrickItem item = _objectPool.Get<BrickItem>(config.ViewPrefab, at);

			item.Initialize(
        config.ViewPrefab, gridData.CellWidth, gridData.CellHeight, config.ScoreValue, config.ExcludedLoot);
		}
	}
}