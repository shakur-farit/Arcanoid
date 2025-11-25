using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
	public class ObjectPoolService : IObjectPoolService
	{
		private readonly Dictionary<GameObject, Queue<GameObject>> _pools = new();
		private readonly IInstantiator _instantiator;
		private readonly Transform _rootContainer;

		public ObjectPoolService(IInstantiator instantiator)
		{
			_instantiator = instantiator;

			GameObject rootGameObject = new GameObject("ObjectPool");
			Object.DontDestroyOnLoad(rootGameObject);
			_rootContainer = rootGameObject.transform;
		}

		public void WarmUp(GameObject prefab, int count)
		{
			if (_pools.ContainsKey(prefab) == false)
				_pools[prefab] = new Queue<GameObject>();

			for (int i = 0; i < count; i++)
			{
				GameObject instance = CreateInstance(prefab, Vector3.zero);
				Return(prefab, instance);
			}
		}

		public GameObject Get(GameObject prefab, Vector3 at)
		{
			if (_pools.TryGetValue(prefab, out Queue<GameObject> queue) && queue.Count > 0)
			{
				GameObject instance = queue.Dequeue();
				instance.gameObject.SetActive(true);
				instance.transform.position = at;
				return instance;
			}

			return CreateInstance(prefab, at);
		}

		public void Return(GameObject prefab, GameObject instance)
		{
			if (_pools.ContainsKey(prefab) == false)
				_pools[prefab] = new Queue<GameObject>();

			instance.gameObject.SetActive(false);
			instance.transform.SetParent(_rootContainer);
			_pools[prefab].Enqueue(instance);
		}

		private GameObject CreateInstance(GameObject prefab, Vector3 at)
		{
			GameObject instance = _instantiator.InstantiatePrefabForComponent<GameObject>(
				prefab,
				position: at,
				rotation: Quaternion.identity,
				parentTransform: _rootContainer);

			return instance;
		}
	}
}