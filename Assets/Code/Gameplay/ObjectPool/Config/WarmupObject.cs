using System;
using UnityEngine;

namespace Code.Gameplay.ObjectPool.Config
{
	[Serializable]
	public class WarmupObject
	{
		public GameObject ViewPrefab;
		public int Count;
	}
}