using Code.Gameplay.Paddle.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Paddle.Behaviour
{
	public class PaddleItem : MonoBehaviour
	{
    private IPaddleService _paddleService;

    public GameObject ViewPrefab { get; private set; }
    public float MovementSpeed { get; private set; }

    [Inject]
    public void Constructor(IPaddleService paddleService) => 
      _paddleService = paddleService;

    public void Initialize(GameObject viewPrefab, float movementSpeed)
    {
      ViewPrefab = viewPrefab;
      MovementSpeed = movementSpeed;

      _paddleService.SetPaddle(this);
    }
  }
}