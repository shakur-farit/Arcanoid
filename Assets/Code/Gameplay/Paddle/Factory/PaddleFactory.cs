using Code.Infrastructure.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
	public class PaddleFactory : IPaddleFactory
	{
		private readonly IInstantiator _instantiator;
		private readonly IStaticDataService _staticDataService;

		public PaddleFactory(IInstantiator instantiator, IStaticDataService staticDataService)
		{
			_instantiator = instantiator;
			_staticDataService = staticDataService;
		}

		public void CreatePaddle()
		{
			PaddleConfig config = _staticDataService.GetPaddleConfig();

			PaddleItem item = _instantiator.InstantiatePrefabForComponent<PaddleItem>(
				config.ViewPrefab, config.StartPosition, Quaternion.identity, null);

			item.Initialize(config.MovementSpeed);
		}
	}
}