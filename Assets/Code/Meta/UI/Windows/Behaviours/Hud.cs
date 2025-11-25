using Code.Gameplay.Score.Service;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class Hud : BaseWindow
	{
		[Inject]
		public void Constructor(IScoreService scoreService)
		{
			Id = WindowId.Hud;
		}
	}
}