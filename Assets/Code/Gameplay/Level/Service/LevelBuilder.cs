using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class LevelBuilder : ILevelBuilder
	{
		private readonly IGridGeneratorFactory _generatorFactory;
		private readonly IBrickFactory _brickFactory;
		private readonly IValidPositionProvider _positionProvider;
		private readonly IGridDataProvider _gridDataProvider;

		public LevelBuilder(
			IGridGeneratorFactory generatorFactory, 
			IBrickFactory brickFactory, 
			IValidPositionProvider positionProvider,
			IGridDataProvider gridDataProvider)
		{
			_generatorFactory = generatorFactory;
			_brickFactory = brickFactory;
			_positionProvider = positionProvider;
			_gridDataProvider = gridDataProvider;
		}

		public void CreateLevel()
		{
			IGridGenerator gridGenerator =_generatorFactory.Create(GridTypeId.CheckmateTriangle);
			gridGenerator.GenerateGrid();

			GridData gridData = _gridDataProvider.GetGridData();

			foreach (Vector2 validPosition in _positionProvider.GetValidPositions())
			{
				_brickFactory.CreateBrick(validPosition, gridData);
			}
		}
	}
}