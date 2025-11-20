using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class BrickItem : MonoBehaviour
	{
		[SerializeField] private Transform _transform;

		public void Initialize(float width, float height) => 
			_transform.localScale = new Vector2(width,height);
	}
}