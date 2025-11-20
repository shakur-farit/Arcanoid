using Code.Gameplay.Camera.Service;
using Code.Gameplay.Death;
using Code.Gameplay.Environment;
using Code.Gameplay.Input;
using Code.Gameplay.Restart;
using Code.Infrastructure.AssetsProvider;
using Code.Infrastructure.Loading;
using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.StaticData;
using Code.Meta.UI.Windows.Factory;
using Code.Meta.UI.Windows.Service;
using Zenject;

namespace Code.Infrastructure.Installers
{
	public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
	{
		public override void InstallBindings()
		{
      BindInfrastructureServices();

      BindStateMachine();
      BindStateMachineFactory();
      BindGameStates();

      BindGameplayServices();
			BindGameplayFactories();

			BindUIServices();
			BindUIFactories();

			BindSoundServices();
			BindSoundFactories();
    }

		private void BindStateMachine() => 
			Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

		private void BindStateMachineFactory() => 
			Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

		private void BindGameStates()
		{
			Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadStaticDataState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadingHomeScreenSceneState>().AsSingle();
			Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LoadingGameplaySceneState>().AsSingle();
			Container.BindInterfacesAndSelfTo<GameplayState>().AsSingle();
			Container.BindInterfacesAndSelfTo<LevelCompleteState>().AsSingle();
			Container.BindInterfacesAndSelfTo<GameOverState>().AsSingle();
		}

		private void BindInfrastructureServices()
		{
			Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
			Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
			Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
			Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
		}

		public void BindGameplayServices()
		{
			Container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
			Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
			Container.Bind<IDeathService>().To<DeathService>().AsSingle();
			Container.Bind<IRestartingService>().To<RestartingService>().AsSingle();
			Container.Bind<IValidPositionProvider>().To<ValidPositionProvider>().AsSingle();
			Container.Bind<IGridDataProvider>().To<GridDataProvider>().AsSingle();
			Container.Bind<ILevelBuilder>().To<LevelBuilder>().AsSingle();
    }

		public void BindGameplayFactories()
		{
      Container.Bind<IEnvironmentFactory>().To<EnvironmentFactory>().AsSingle();
      Container.Bind<IBrickFactory>().To<BrickFactory>().AsSingle();

      Container.Bind<IGridGeneratorFactory>().To<GridGeneratorFactory>().AsSingle();

      Container.Bind<SquareGridGenerator>().AsSingle();
      Container.Bind<TriangleGridGenerator>().AsSingle();
		}

    public void BindUIServices() => 
			Container.Bind<IWindowService>().To<WindowService>().AsSingle();

		public void BindUIFactories() =>
			Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();

    public void BindSoundServices() => 
			Container.BindInterfacesAndSelfTo<MusicProvider>().AsSingle();

    public void BindSoundFactories()
    {
    }

    public void Initialize() => 
			Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
  }
}
