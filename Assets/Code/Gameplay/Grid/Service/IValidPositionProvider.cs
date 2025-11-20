using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Environment
{
  public interface IValidPositionProvider
  {
	  List<Vector2> GetValidPositions();
	  void SetValidPositions(List<Vector2> validPositions);
  }
}