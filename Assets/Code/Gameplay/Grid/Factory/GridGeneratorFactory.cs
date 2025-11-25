using Code.Gameplay.Grid.Service;
using Zenject;

namespace Code.Gameplay.Grid.Factory
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
				GridTypeId.CheckmateSquare => _container.Resolve<CheckmateSquareGridGenerator>(),
				GridTypeId.CheckmateTriangle => _container.Resolve<CheckmateTriangleGridGenerator>(),
				_ => throw new System.NotImplementedException(
					$"Grid type {typeId} not supported")
			};
		}
	}
}