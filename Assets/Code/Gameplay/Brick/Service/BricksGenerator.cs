using Code.Gameplay.Brick.Factory;
using Code.Gameplay.Grid.Service;
using UnityEngine;

namespace Code.Gameplay.Brick.Service
{
	public class BricksGenerator : IBricksGenerator
	{
		private readonly IGridDataProvider _gridDataProvider;
		private readonly IValidPositionProvider _positionProvider;
		private readonly IBrickFactory _brickFactory;

		public BricksGenerator(
			IGridDataProvider gridDataProvider, 
			IValidPositionProvider positionProvider,
			IBrickFactory brickFactory)
		{
			_gridDataProvider = gridDataProvider;
			_positionProvider = positionProvider;
			_brickFactory = brickFactory;
		}

		public void Generate()
		{
			GridData gridData = _gridDataProvider.GetGridData();

			foreach (Vector2 validPosition in _positionProvider.GetValidPositions())
			{
				_brickFactory.CreateBrick(validPosition, gridData);
			}
		}
	}
}