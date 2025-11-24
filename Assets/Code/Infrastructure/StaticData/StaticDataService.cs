using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Environment;
using Code.Infrastructure.AssetsProvider;
using Code.Infrastructure.States.GameStates;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Config;
using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.StaticData
{
	public class StaticDataService : IStaticDataService
	{
    private const string LevelConfigPath = "LevelConfig";
    private const string EnvironmentConfigPath = "EnvironmentConfig";
    private const string GridConfigPath = "GridConfig";
    private const string BrickConfigPath = "BrickConfig";
    private const string PaddleConfigPath = "PaddleConfig";
    private const string BallConfigPath = "BallConfig";

    private const string WindowConfigLabel = "WindowConfig";
    private const string MusicConfigLabel = "MusicConfig";
    private const string SoundEffectConfigLabel = "SoundEffectConfig";

    private LevelConfig _level;
    private EnvironmentConfig _environment;
    private GridConfig _grid;
    private BrickConfig _brick;
    private PaddleConfig _paddle;
    private BallConfig _ball;

    private Dictionary<WindowId, WindowConfig> _windowById;
    private Dictionary<MusicTypeId, MusicConfig> _musicById;
    private Dictionary<SoundEffectTypeId, SoundEffectConfig> _soundEffectById;

    private readonly IAssetProvider _assetProvider;

		public StaticDataService(IAssetProvider assetProvider) => 
			_assetProvider = assetProvider;

		public async UniTask LoadAll()
		{
      await LoadLevel();
      await LoadEnvironment();
      await LoadGrid();
      await LoadBrick();
      await LoadPaddle();
      await LoadBall();
      await LoadWindows();
      await LoadMusic();
      await LoadSoundEffects();
    }

		public LevelConfig GetLevelConfig() => 
			_level;

		public EnvironmentConfig GetEnvironmentConfig() => 
      _environment;

    public GridConfig GetGridConfig() =>
      _grid;

    public BrickConfig GetBrickConfig() => 
	    _brick;

    public PaddleConfig GetPaddleConfig() =>
	    _paddle;

    public BallConfig GetBallConfig() =>
      _ball;

    public WindowConfig GetWindowConfig(WindowId id)
		{
			if (_windowById.TryGetValue(id, out WindowConfig config))
				return config;

			throw new Exception($"Window config for {id} was not found");
		}

    public MusicConfig GetMusicConfig(MusicTypeId id)
    {
      if (_musicById.TryGetValue(id, out MusicConfig config))
        return config;

      throw new Exception($"Music config for {id} was not found");
    }

    public SoundEffectConfig GetSoundEffectConfig(SoundEffectTypeId id)
    {
      if (_soundEffectById.TryGetValue(id, out SoundEffectConfig config))
        return config;

      throw new Exception($"Sound effect config for {id} was not found");
    }

    private async UniTask LoadLevel() => 
	    _level = await _assetProvider.Load<LevelConfig>(LevelConfigPath);

    private async UniTask LoadEnvironment() =>
      _environment = await _assetProvider.Load<EnvironmentConfig>(EnvironmentConfigPath);

    private async UniTask LoadGrid() =>
      _grid = await _assetProvider.Load<GridConfig>(GridConfigPath);

    private async UniTask LoadBrick() =>
	    _brick = await _assetProvider.Load<BrickConfig>(BrickConfigPath);

    private async UniTask LoadPaddle() =>
	    _paddle = await _assetProvider.Load<PaddleConfig>(PaddleConfigPath);

    private async UniTask LoadBall() =>
      _ball = await _assetProvider.Load<BallConfig>(BallConfigPath);

    private async UniTask LoadWindows() =>
			_windowById = (await _assetProvider.LoadAll<WindowConfig>(WindowConfigLabel))
				.ToDictionary(x => x.TypeId, x => x);

    private async UniTask LoadMusic() =>
      _musicById = (await _assetProvider.LoadAll<MusicConfig>(MusicConfigLabel))
        .ToDictionary(x => x.TypeId, x => x);

    private async UniTask LoadSoundEffects() =>
      _soundEffectById = (await _assetProvider.LoadAll<SoundEffectConfig>(SoundEffectConfigLabel))
        .ToDictionary(x => x.TypeId, x => x);
  }
}