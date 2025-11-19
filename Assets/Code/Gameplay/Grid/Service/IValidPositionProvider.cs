using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
  public interface IValidPositionProvider
  {
    void SetValidPositions(List<Vector2> validPositions);
    List<Vector2> GetValidPositions();
  }
}