using Code.Gameplay.Score.Service;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Score.Behaviour
{
	public class ScoreTextUpdater : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _scoreText;

		private IScoreService _scoreService;

		[Inject]
		public void Constructor(IScoreService scoreService) => 
			_scoreService = scoreService;

		private void Start() => 
			UpdateScoreText();

		private void OnEnable() =>
			_scoreService.ScoreChanged += UpdateScoreText;

		private void OnDisable() => 
			_scoreService.ScoreChanged -= UpdateScoreText;

		private void UpdateScoreText() =>
			_scoreText.text = $"Score: {_scoreService.Score.ToString()}";
	}
}