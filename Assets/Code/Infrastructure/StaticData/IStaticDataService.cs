using Code.Gameplay.Environment;
using Code.Infrastructure.States.GameStates;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StaticData
{
	public interface IStaticDataService
	{
		UniTask LoadAll();

    EnvironmentConfig GetEnvironmentConfig();
    GridConfig GetGridConfig();
    BrickConfig GetBrickConfig();
    WindowConfig GetWindowConfig(WindowId id);
    MusicConfig GetMusicConfig(MusicTypeId id);
	}
}