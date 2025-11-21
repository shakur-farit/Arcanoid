using Code.Gameplay.Input;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
	public class PaddleMover : MonoBehaviour
	{
		[SerializeField] private PaddleItem _item;
		[SerializeField] private Rigidbody2D _rigidbody2D;

		private IInputService _inputService;

		[Inject]
		public void Constructor(IInputService inputService) => 
			_inputService = inputService;

		private void FixedUpdate()
		{
			if (_inputService == null)
				return;

			Vector2 targetPosition = _inputService.GetWorldMousePosition();

			Move(targetPosition.x);
		}

		private void Move(float targetX)
		{
			float currentX = _rigidbody2D.position.x;
			float direction = targetX - currentX;

			float velocityX = Mathf.Clamp(
				direction / Time.deltaTime, -_item.MovementSpeed, _item.MovementSpeed);

			_rigidbody2D.velocity = new Vector2(velocityX, _rigidbody2D.velocity.y);
		}
	}
}