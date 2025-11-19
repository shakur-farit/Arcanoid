using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class GridFactory : IGridFactory
  {
    private readonly IGridDataProvider _gridDataProvider;
    private readonly IValidPositionProvider _validPositionProvider;

    public GridFactory(IGridDataProvider gridDataProvider, IValidPositionProvider validPositionProvider)
    {
      _gridDataProvider = gridDataProvider;
      _validPositionProvider = validPositionProvider;
    }

    public void CreateGrid()
    {
      GridData gridData = _gridDataProvider.GetGridData();

      List<Vector2> positions = new();

      float startX = gridData.StartPosition.x;
      float startY = gridData.StartPosition.y;

      for (int x = 0; x < gridData.XSize; x++)
      for (int y = 0; y < gridData.YSize; y++)
      {
        Vector2 cellPos = new Vector2(
          startX + x * gridData.CellSize,
          startY + y * gridData.CellSize);

        positions.Add(cellPos);
      }

      _validPositionProvider.SetValidPositions(positions);
    }
  }
}