using Code.Gameplay.Ball.Config;
using Code.Gameplay.Brick.Config;
using Code.Gameplay.Environment.Config;
using Code.Gameplay.Grid.Config;
using Code.Gameplay.Level.Config;
using Code.Gameplay.Loot;
using Code.Gameplay.Loot.Config;
using Code.Gameplay.ObjectPool.Config;
using Code.Gameplay.Paddle.Config;
using Code.Infrastructure.States.GameStates;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StaticData
{
	public interface IStaticDataService
	{
		UniTask LoadAll();

		LevelConfig GetLevelConfig();
		EnvironmentConfig GetEnvironmentConfig();
		GridConfig GetGridConfig();
    BrickConfig GetBrickConfig();
    PaddleConfig GetPaddleConfig();
    BallConfig GetBallConfig();
    ObjectPoolConfig GetObjectPoolConfig();
    WindowConfig GetWindowConfig(WindowId id);
    MusicConfig GetMusicConfig(MusicTypeId id);
    SoundEffectConfig GetSoundEffectConfig(SoundEffectTypeId id);
    LootConfig GetLootConfig(LootTypeId id);
	}
}