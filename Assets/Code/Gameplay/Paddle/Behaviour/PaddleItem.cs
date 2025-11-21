using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class PaddleItem : MonoBehaviour
	{
		public float MovementSpeed { get; private set; }

		public void Initialize(float movementSpeed) => 
			MovementSpeed = movementSpeed;
	}
}