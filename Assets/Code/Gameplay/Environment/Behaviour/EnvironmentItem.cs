using System;
using Code.Meta.UI.Windows;
using Code.Meta.UI.Windows.Factory;
using Code.Meta.UI.Windows.Service;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  public class EnvironmentItem : MonoBehaviour
  {
    private IEnvironmentService _environmentService;

    public float BorderThickness { get; private set; }
    public float BorderPadding { get; private set; }

    [Inject]
    public void Constructor(IEnvironmentService environmentService) =>
      _environmentService = environmentService;

    public void Initialize(float borderThickness, float borderPadding)
    {
      BorderThickness = borderThickness;
      BorderPadding = borderPadding;

      _environmentService.SetEnvironment(this);
    }
  }
}