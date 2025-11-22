using System;
using Code.Gameplay.Environment;
using TMPro;
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