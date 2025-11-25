using System.Collections.Generic;

namespace Code.Gameplay.Environment
{
	public class LevelCleaner : ILevelCleaner
	{
    private readonly IEnumerable<ICleanable> _removables;

    public LevelCleaner(IEnumerable<ICleanable> removables) => 
      _removables = removables;

    public void CleanLevel()
		{
      foreach (ICleanable removable in _removables)
        removable.Clean();
    }
  }
}