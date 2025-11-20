using Zenject;

namespace Code.Gameplay.Environment
{
	public class GridGeneratorFactory : IGridGeneratorFactory
	{
		private readonly DiContainer _container;

		public GridGeneratorFactory(DiContainer container) => 
			_container = container;

		public IGridGenerator Create(GridTypeId typeId)
		{
			return typeId switch
			{
				GridTypeId.Square => _container.Resolve<SquareGridGenerator>(),
				GridTypeId.Triangle => _container.Resolve<TriangleGridGenerator>(),
				_ => throw new System.NotImplementedException(
					$"Grid type {typeId} not supported")
			};
		}
	}
}