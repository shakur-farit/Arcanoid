using System.Collections.Generic;
using Code.Gameplay.Brick.Behaviour;

namespace Code.Gameplay.Brick.Service
{
	public interface IBrickService
	{
		void RemoveBrick(BrickItem item);
		void AddBrick(BrickItem item);
		List<BrickItem> GetBricks();
	}
}