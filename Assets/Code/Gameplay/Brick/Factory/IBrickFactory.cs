using UnityEngine;

namespace Code.Gameplay.Environment
{
	public interface IBrickFactory
	{
		BrickItem CreateBrick(Vector2 at);
	}
}