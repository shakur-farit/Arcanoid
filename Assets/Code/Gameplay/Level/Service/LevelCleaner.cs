using System.Collections.Generic;

namespace Code.Gameplay.Environment
{
	public class LevelCleaner : ILevelCleaner
	{
    private readonly IEnumerable<IRemovable> _removables;

    public LevelCleaner(IEnumerable<IRemovable> removables) => 
      _removables = removables;

    public void CleanLevel()
		{
      foreach (IRemovable removable in _removables)
        removable.Remove();
    }
  }
}