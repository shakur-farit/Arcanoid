using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
	public class PaddleItem : MonoBehaviour
	{
    private IPaddleService _paddleService;

    public float MovementSpeed { get; private set; }

    [Inject]
    public void Constructor(IPaddleService paddleService) => 
      _paddleService = paddleService;

    public void Initialize(float movementSpeed)
    {
      MovementSpeed = movementSpeed;

      _paddleService.SetPaddle(this);
    }
  }
}