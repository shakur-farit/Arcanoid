using Code.Gameplay.Camera.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class BorderInitializer : MonoBehaviour
  {
    [SerializeField] private EdgeCollider2D _upBorder;
    [SerializeField] private EdgeCollider2D _downBorder;
    [SerializeField] private EdgeCollider2D _leftBorder;
    [SerializeField] private EdgeCollider2D _rightBorder;

    private ICameraProvider _cameraProvider;

    [Inject]
    public void Constructor(ICameraProvider cameraProvider) => 
      _cameraProvider = cameraProvider;

    private void Start() => 
      InitializeBorder();

    private void InitializeBorder()
    {
      UnityEngine.Camera mainCamera = _cameraProvider.MainCamera;

      Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new(0, 0, mainCamera.nearClipPlane));
      Vector3 bottomRight = mainCamera.ViewportToWorldPoint(new (1, 0, mainCamera.nearClipPlane));
      Vector3 topLeft = mainCamera.ViewportToWorldPoint(new (0, 1, mainCamera.nearClipPlane));
      Vector3 topRight = mainCamera.ViewportToWorldPoint(new(1, 1, mainCamera.nearClipPlane));

      SetEdgeCollider(_upBorder, topLeft, topRight);
      SetEdgeCollider(_downBorder, bottomLeft, bottomRight);
      SetEdgeCollider(_leftBorder, bottomLeft, topLeft);
      SetEdgeCollider(_rightBorder, bottomRight, topRight);
    }

    private void SetEdgeCollider(EdgeCollider2D edge, Vector2 p1, Vector2 p2) => 
      edge.points = new[] { p1, p2 };
  }
}