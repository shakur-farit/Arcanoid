using UnityEngine;

namespace Code.Gameplay.Environment
{
	[CreateAssetMenu(menuName = "Arcanoid/Paddle Config", fileName = "PaddleConfig")]
	public class PaddleConfig : ScriptableObject
	{
		public GameObject ViewPrefab;
		public Vector2 StartPosition;
		public float MovementSpeed;
	}
}