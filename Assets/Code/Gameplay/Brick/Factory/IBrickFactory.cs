using Code.Gameplay.Grid.Service;
using UnityEngine;

namespace Code.Gameplay.Brick.Factory
{
	public interface IBrickFactory
	{
		void CreateBrick(Vector2 at, GridData gridData);
	}
}