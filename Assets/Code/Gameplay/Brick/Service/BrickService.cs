using System.Collections.Generic;
using Code.Gameplay.Brick.Behaviour;
using Code.Gameplay.Level.Service;
using Code.Gameplay.ObjectPool.Service;

namespace Code.Gameplay.Brick.Service
{
	public class BrickService : IBrickService, ICleanable
	{
    private readonly IObjectPoolService _objectPool;
    private readonly List<BrickItem> _bricks = new();

    public BrickService(IObjectPoolService objectPool) => 
      _objectPool = objectPool;

    public List<BrickItem> GetBricks() => 
			_bricks;

		public void RemoveBrick(BrickItem brick)
		{
			_bricks.Remove(brick);

			DestroyBrick(brick);
		}

		public void AddBrick(BrickItem brick) => 
			_bricks.Add(brick);

    public void Clean()
    {
      foreach (BrickItem brick in _bricks)
        DestroyBrick(brick);

      _bricks.Clear();
    }

    private void DestroyBrick(BrickItem brick) => 
      _objectPool.Return(brick.ViewPrefab, brick.gameObject);
  }
}