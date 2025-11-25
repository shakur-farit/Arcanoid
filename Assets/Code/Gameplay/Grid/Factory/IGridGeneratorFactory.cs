using Code.Gameplay.Grid.Service;

namespace Code.Gameplay.Grid.Factory
{
	public interface IGridGeneratorFactory
	{
		IGridGenerator Create(GridTypeId typeId);
	}
}