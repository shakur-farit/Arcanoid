using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class BrickProvider : IBrickProvider
	{
		private List<BrickItem> _bricks = new();

		public List<BrickItem> GetBricks() => 
			_bricks;

		public void RemoveBrick(BrickItem item)
		{
			_bricks.Remove(item);
			Object.Destroy(item.gameObject);
		}

		public void AddBrick(BrickItem item) => 
			_bricks.Add(item);
	}
}