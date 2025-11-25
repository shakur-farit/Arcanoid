using UnityEngine;

namespace Code.Gameplay.Level.Config
{
	[CreateAssetMenu(menuName = "Arcanoid/Level Config", fileName = "LevelConfig")]
	public class LevelConfig : ScriptableObject
	{
		[Range(0f, 100f)] public float BallMovementSpeedIncreaseValue;
	}
}