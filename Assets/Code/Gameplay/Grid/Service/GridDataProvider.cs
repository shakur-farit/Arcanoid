using Code.Gameplay.Camera.Service;
using Code.Infrastructure.StaticData;
using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class GridDataProvider : IGridDataProvider
  {
    private readonly ICameraProvider _cameraProvider;
    private readonly IStaticDataService _staticDataService;

    public GridDataProvider(ICameraProvider cameraProvider, IStaticDataService staticDataService)
    {
      _cameraProvider = cameraProvider;
      _staticDataService = staticDataService;
    }

    public GridData GetGridData()
    {
      GridConfig config = _staticDataService.GetGridConfig();

      UnityEngine.Camera mainCamera = _cameraProvider.MainCamera;

      Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
      Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

      bottomLeft.x += config.LeftPadding;
      topRight.x -= config.RightPadding;
      topRight.y -= config.TopPadding;

      float availableWidth = topRight.x - bottomLeft.x;
      float availableHeight = topRight.y - bottomLeft.y;

      int gridWidth = Mathf.FloorToInt(availableWidth / config.CellWidth);
      int gridHeight = Mathf.FloorToInt(availableHeight / config.CellHeight);

      float leftoverX = availableWidth - gridWidth * config.CellWidth;

      Vector2 startPosition = new Vector2(
        bottomLeft.x + leftoverX / 2f,
        topRight.y
      );

      return new GridData
      {
        XSize = gridWidth,
        YSize = gridHeight,
        CellWidth = config.CellWidth,
        CellHeight = config.CellHeight,
        StartPosition = startPosition
      };
    }
  }
}