using UnityEngine;

namespace Code.Meta.UI.Windows.Config
{
	[CreateAssetMenu(menuName = "Arcanoid/Window Config", fileName = "WindowConfig")]
	public class WindowConfig : ScriptableObject
	{
		public WindowId TypeId;
		public GameObject ViewPrefab;
	}
}