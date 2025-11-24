using UnityEngine;

namespace Code.Gameplay.Environment
{
	[CreateAssetMenu(menuName = "Arcanoid/Level Config", fileName = "LevelConfig")]
	public class LevelConfig : ScriptableObject
	{
		[Range(0f, 100f)] public float BallMovementSpeedIncreaseValue;
	}
}