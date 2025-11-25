using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
	[CreateAssetMenu(menuName = "Arcanoid/Object Pool Config", fileName = "ObjectPoolConfig")]
	public class ObjectPoolConfig : ScriptableObject
	{
		public List<WarmupObject> WarmupObjects;
	}
}