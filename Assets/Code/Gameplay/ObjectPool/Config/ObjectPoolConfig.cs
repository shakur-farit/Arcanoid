using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.ObjectPool.Config
{
	[CreateAssetMenu(menuName = "Arcanoid/Object Pool Config", fileName = "ObjectPoolConfig")]
	public class ObjectPoolConfig : ScriptableObject
	{
		public List<WarmupObject> WarmupObjects;
	}
}