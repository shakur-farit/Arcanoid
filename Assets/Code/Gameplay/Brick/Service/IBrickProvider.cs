using System.Collections.Generic;

namespace Code.Gameplay.Environment
{
	public interface IBrickProvider
	{
		void RemoveBrick(BrickItem item);
		void AddBrick(BrickItem item);
		List<BrickItem> GetBricks();
	}
}