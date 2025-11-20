using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class SquareGridGenerator : IGridGenerator
	{
		private readonly IGridDataProvider _gridDataProvider;
		private readonly IValidPositionProvider _positionProvider;

		public SquareGridGenerator(IGridDataProvider gridDataProvider, IValidPositionProvider positionProvider)
		{
			_gridDataProvider = gridDataProvider;
			_positionProvider = positionProvider;
		}

		public void GenerateGrid()
		{
			List<Vector2> validPositions = new List<Vector2>();

			GridData gridData = _gridDataProvider.GetGridData();

			float startX = gridData.StartPosition.x;
			float startY = gridData.StartPosition.y;

			for (int y = 0; y < gridData.XSize; y++)
			for (int x = 0; x < gridData.XSize; x++)
			{
				Vector2 cellPos = new Vector2(
					startX + x * gridData.CellWidth + gridData.CellWidth / 2f,
					startY - y * gridData.CellHeight - gridData.CellHeight / 2f
				);

				validPositions.Add(cellPos);
			}

			_positionProvider.SetValidPositions(validPositions);
		}
	}
}