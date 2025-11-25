using Code.Gameplay.Score.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Brick.Behaviour
{
  public class ScoreIncreaser : MonoBehaviour
  {
    private IScoreService _scoreService;

    [Inject]
    public void Constructor(IScoreService scoreService) => 
      _scoreService = scoreService;

    public void IncreaseScore(int value) => 
      _scoreService.IncreaseScore(value);
  }
}