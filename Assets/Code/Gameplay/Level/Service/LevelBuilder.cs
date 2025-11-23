namespace Code.Gameplay.Environment
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
			IGridGenerator gridGenerator = _generatorFactory.Create(GridTypeId.CheckmateTriangle);
			gridGenerator.GenerateGrid();
		}

		private void CreateEnvironment() => 
			_environmentFactory.CreateEnvironment();

		private void GenerateBricks() => 
			_bricksGenerator.Generate();
	}
}