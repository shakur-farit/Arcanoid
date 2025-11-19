using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.Windows.Behaviours
{
	public class Hud : BaseWindow
	{
		[SerializeField] private TextMeshProUGUI _scoreText;


		[Inject]
		public void Constructor()
		{
			Id = WindowId.Hud;

		}
  }
}