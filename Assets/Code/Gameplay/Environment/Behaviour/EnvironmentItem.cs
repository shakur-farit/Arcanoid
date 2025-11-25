using Code.Gameplay.Environment.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment.Behaviour
{
  public class EnvironmentItem : MonoBehaviour
  {
    private IEnvironmentService _environmentService;

    public GameObject ViewPrefab { get; private set; }
    public float BorderThickness { get; private set; }
    public float BorderPadding { get; private set; }

    [Inject]
    public void Constructor(IEnvironmentService environmentService) =>
      _environmentService = environmentService;

    public void Initialize(GameObject viewPrefab, float borderThickness, float borderPadding)
    {
      ViewPrefab = viewPrefab;
      BorderThickness = borderThickness;
      BorderPadding = borderPadding;

      _environmentService.SetEnvironment(this);
    }
  }
}