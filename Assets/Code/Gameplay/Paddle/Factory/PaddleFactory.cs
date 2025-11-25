using Code.Gameplay.ObjectPool.Service;
using Code.Gameplay.Paddle.Behaviour;
using Code.Gameplay.Paddle.Config;
using Code.Infrastructure.StaticData;

namespace Code.Gameplay.Paddle.Factory
{
	public class PaddleFactory : IPaddleFactory
	{
    private readonly IObjectPoolService _objectPool;
    private readonly IStaticDataService _staticDataService;

		public PaddleFactory(IObjectPoolService objectPool, IStaticDataService staticDataService)
		{
      _objectPool = objectPool;
      _staticDataService = staticDataService;
		}

		public void CreatePaddle()
		{
			PaddleConfig config = _staticDataService.GetPaddleConfig();

			PaddleItem item = _objectPool.Get<PaddleItem>(config.ViewPrefab, config.StartPosition);

			item.Initialize(config.ViewPrefab, config.MovementSpeed);
		}
	}
}