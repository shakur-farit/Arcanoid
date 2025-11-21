using System;
using Code.Gameplay.Camera.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class BorderInitializer : MonoBehaviour
  {
    [SerializeField] private EnvironmentItem _item;
    [SerializeField] private Transform _topBorder;
	  [SerializeField] private Transform _bottomBorder;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

		private ICameraProvider _cameraProvider;

    [Inject]
    public void Constructor(ICameraProvider cameraProvider) => 
      _cameraProvider = cameraProvider;

    private void Start() => 
	    InitializeBorder(_item.BorderThickness, _item.BorderThickness);

    private void InitializeBorder(float borderThickness, float borderPadding)
    {
      UnityEngine.Camera mainCamera = _cameraProvider.MainCamera;

      Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
      Vector3 bottomRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));
      Vector3 topLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane));
      Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

      bottomLeft += new Vector3(borderPadding, borderPadding);
      bottomRight += new Vector3(-borderPadding, borderPadding);
      topLeft += new Vector3(borderPadding, -borderPadding);
      topRight += new Vector3(-borderPadding, -borderPadding);

			float width = Vector2.Distance(topLeft, topRight);
      float height = Vector2.Distance(bottomLeft, topLeft);

			InitTopBorder(borderThickness, topLeft, width);
      
      InitBottomBorder(borderThickness, bottomLeft, width);

      InitLeftBorder(borderThickness, bottomLeft, height);

      InitRightBorder(borderThickness, bottomRight, height);
		}

    private void InitTopBorder(float borderThickness, Vector3 topLeft, float width)
    {
	    _topBorder.position = new Vector3(0, topLeft.y, 0);
	    _topBorder.localScale = new Vector3(width, borderThickness, 1);
    }

    private void InitBottomBorder(float borderThickness, Vector3 bottomLeft, float width)
    {
	    _bottomBorder.position = new Vector3(0, bottomLeft.y, 0);
	    _bottomBorder.localScale = new Vector3(width, borderThickness, 1);
    }

    private void InitLeftBorder(float borderThickness, Vector3 bottomLeft, float height)
    {
	    _leftBorder.position = new Vector3(bottomLeft.x, 0, 0);
	    _leftBorder.localScale = new Vector3(borderThickness, height, 1);
    }

    private void InitRightBorder(float borderThickness, Vector3 bottomRight, float height)
    {
	    _rightBorder.position = new Vector3(bottomRight.x, 0, 0);
	    _rightBorder.localScale = new Vector3(borderThickness, height, 1);
    }
  }
}