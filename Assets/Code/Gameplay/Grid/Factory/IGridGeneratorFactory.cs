namespace Code.Gameplay.Environment
{
	public interface IGridGeneratorFactory
	{
		IGridGenerator Create(GridTypeId typeId);
	}
}