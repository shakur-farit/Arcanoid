using Code.Gameplay.Camera.Service;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Input
{
	public class StandaloneInputService : IInputService
	{
    private Vector3 _screenPosition;

    private readonly ICameraProvider _cameraProvider;

    public StandaloneInputService(ICameraProvider cameraProvider) => 
			_cameraProvider = cameraProvider;

    public Vector2 GetScreenMousePosition() =>
			_cameraProvider.MainCamera ? UnityEngine.Input.mousePosition : new Vector2();

		public Vector2 GetWorldMousePosition()
		{
			if (_cameraProvider.MainCamera == null)
				return Vector2.zero;

			_screenPosition.x = UnityEngine.Input.mousePosition.x;
			_screenPosition.y = UnityEngine.Input.mousePosition.y;

			return _cameraProvider.MainCamera.ScreenToWorldPoint(_screenPosition);
		}

		public bool HasAxisInput() => GetHorizontalAxis() != 0 || GetVerticalAxis() != 0;

		public float GetVerticalAxis() => UnityEngine.Input.GetAxisRaw("Vertical");
		public float GetHorizontalAxis() => UnityEngine.Input.GetAxisRaw("Horizontal");


		public bool GetLeftMouseButton() =>
			UnityEngine.Input.GetMouseButton(0) /*&& !EventSystem.current.IsPointerOverGameObject()*/;

		public bool GetLeftMouseButtonDown() =>
			UnityEngine.Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();

		public bool GetLeftMouseButtonUp() =>
      UnityEngine.Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject();

    public bool GetJumpButton() =>
      UnityEngine.Input.GetKey(KeyCode.Space);

    public bool GetJumpButtonDown() =>
      UnityEngine.Input.GetKeyDown(KeyCode.Space);

    public bool GetJumpButtonUp() =>
      UnityEngine.Input.GetKeyUp(KeyCode.Space);
  }
}