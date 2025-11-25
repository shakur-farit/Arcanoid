using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class BrickService : IBrickService, ICleanable
	{
		private readonly List<BrickItem> _bricks = new();

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

			Debug.Log("CleaerBrciks");
    }

    private void DestroyBrick(BrickItem brick) => 
      Object.Destroy(brick.gameObject);
  }
}