using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
  public class ValidPositionProvider : IValidPositionProvider
  {
    private List<Vector2> _validPositions = new();

    public void SetValidPositions(List<Vector2> validPositions) => 
      _validPositions = validPositions;

    public List<Vector2> GetValidPositions() => 
      _validPositions;
  }
}