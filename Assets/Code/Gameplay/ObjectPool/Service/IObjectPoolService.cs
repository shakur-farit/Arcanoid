using UnityEngine;

namespace Code.Gameplay.Environment
{
	public interface IObjectPoolService
	{
		void WarmUp(GameObject prefab, int count);
		GameObject Get(GameObject prefab, Vector3 at);
		void Return(GameObject prefab, GameObject instance);
	}
}