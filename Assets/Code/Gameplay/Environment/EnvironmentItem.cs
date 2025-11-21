using UnityEngine;

namespace Code.Gameplay.Environment
{
	public class EnvironmentItem : MonoBehaviour
	{
		public float BorderThickness { get; private set; }
		public float BorderPadding { get; private set; }

		public void Initialize(float borderThickness, float borderPadding)
		{
			BorderThickness = borderThickness;
			BorderPadding = borderPadding;
		}
	}
}