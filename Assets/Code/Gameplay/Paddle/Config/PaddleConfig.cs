using UnityEngine;

namespace Code.Gameplay.Paddle.Config
{
	[CreateAssetMenu(menuName = "Arcanoid/Paddle Config", fileName = "PaddleConfig")]
	public class PaddleConfig : ScriptableObject
	{
		public GameObject ViewPrefab;
		public Vector2 StartPosition;
		public float MovementSpeed;
	}
}