using Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
	public class BrickFactory : IBrickFactory
	{
		private readonly IInstantiator _instantiator;
		private readonly IStaticDataService _staticDataService;

		public BrickFactory(IInstantiator instantiator, IStaticDataService staticDataService)
		{
			_instantiator = instantiator;
			_staticDataService = staticDataService;
		}

		public void CreateBrick(Vector2 at, GridData gridData)
		{
			BrickConfig config = _staticDataService.GetBrickConfig();

			BrickItem item = _instantiator.InstantiatePrefabForComponent<BrickItem>(
				config.ViewPrefab, at, Quaternion.identity, null);

			item.Initialize(gridData.CellWidth, gridData.CellHeight, config.ScoreValue);
		}
	}
}