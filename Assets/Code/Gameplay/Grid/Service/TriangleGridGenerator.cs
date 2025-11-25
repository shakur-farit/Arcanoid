using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Grid.Service
{
	public class TriangleGridGenerator : IGridGenerator
	{
    private readonly IGridDataProvider _gridDataProvider;
    private readonly IValidPositionProvider _positionProvider;

    public TriangleGridGenerator(IGridDataProvider gridDataProvider, IValidPositionProvider positionProvider)
    {
      _gridDataProvider = gridDataProvider;
      _positionProvider = positionProvider;
    }

    public void GenerateGrid()
    {
      GridData grid = _gridDataProvider.GetGridData();

      List<Vector2> positions = new();

      float startX = grid.StartPosition.x;
      float startY = grid.StartPosition.y;

      for (int y = 0; y < grid.YSize; y++)
      {
        int cellsInRow = grid.XSize - y * 2;

        if (cellsInRow <= 0)
          break;

        float rowStartX = startX + (y * grid.CellWidth);

        for (int x = 0; x < cellsInRow; x++)
        {
          Vector2 pos = new Vector2(
            rowStartX + x * grid.CellWidth + grid.CellWidth / 2f,
            startY - y * grid.CellHeight - grid.CellHeight / 2f
          );

          positions.Add(pos);
        }
      }

      _positionProvider.SetValidPositions(positions);
    }
  }
}