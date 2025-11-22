using UnityEngine;

namespace Code.Gameplay.Environment
{
	public interface IBrickFactory
	{
		void CreateBrick(Vector2 at, GridData gridData);
	}
}