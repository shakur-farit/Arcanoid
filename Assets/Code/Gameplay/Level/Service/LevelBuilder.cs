using Code.Gameplay.Brick.Service;
using Code.Gameplay.Environment.Factory;
using Code.Gameplay.Grid;
using Code.Gameplay.Grid.Factory;
using Code.Gameplay.Grid.Service;
using UnityEngine;

namespace Code.Gameplay.Level.Service
{
	public class LevelBuilder : ILevelBuilder
	{
		private readonly IGridGeneratorFactory _generatorFactory;
		private readonly IBricksGenerator _bricksGenerator;
		private readonly IEnvironmentFactory _environmentFactory;

		public LevelBuilder(
			IGridGeneratorFactory generatorFactory,
			IBricksGenerator bricksGenerator,
			IEnvironmentFactory environmentFactory)
		{
			_generatorFactory = generatorFactory;
			_bricksGenerator = bricksGenerator;
			_environmentFactory = environmentFactory;
		}

		public void CreateLevel()
		{
			GenerateGrid();
			CreateEnvironment();
			GenerateBricks();
		}

    private void GenerateGrid()
    {
      IGridGenerator gridGenerator = _generatorFactory.Create(GetRandomGridType());
      gridGenerator.GenerateGrid();
    }

    private GridTypeId GetRandomGridType()
    {
      GridTypeId[] types =
      {
        GridTypeId.Triangle,
        GridTypeId.Square,
        GridTypeId.CheckmateTriangle,
        GridTypeId.CheckmateSquare
      };

      return types[Random.Range(0, types.Length)];
    }

    private void CreateEnvironment() => 
			_environmentFactory.CreateEnvironment();

		private void GenerateBricks() => 
			_bricksGenerator.Generate();
	}
}