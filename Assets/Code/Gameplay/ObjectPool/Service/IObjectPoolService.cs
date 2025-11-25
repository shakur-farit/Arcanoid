using UnityEngine;

namespace Code.Gameplay.ObjectPool.Service
{
	public interface IObjectPoolService
	{
		void WarmUp(GameObject prefab, int count);
		T Get<T>(GameObject prefab, Vector3 at) where T : Component;
    GameObject Get(GameObject prefab, Vector3 at);
		void Return(GameObject prefab, GameObject instance);
	}
}