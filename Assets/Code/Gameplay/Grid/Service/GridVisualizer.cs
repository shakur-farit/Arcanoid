using UnityEngine;
using Zenject;

namespace Code.Gameplay.Environment
{
  [ExecuteAlways]
  public class GridVisualizer : MonoBehaviour
  {
    [SerializeField] private Color cellColor = Color.green;
    [SerializeField] private bool drawGizmos = true;

    private IGridDataProvider _gridDataProvider;

    [Inject]
    public void Constructor(IGridDataProvider gridDataProvider)
    {
      _gridDataProvider = gridDataProvider;
    }

    private void OnDrawGizmos()
    {
      if (!drawGizmos) return;

      GridData grid = _gridDataProvider.GetGridData();

      Gizmos.color = cellColor;

      for (int y = 0; y < grid.YSize; y++)
      {
        for (int x = 0; x < grid.XSize; x++)
        {
          Vector2 cellPos = new Vector2(
            grid.StartPosition.x + x * grid.CellSize + grid.CellSize / 2f,
            grid.StartPosition.y - y * grid.CellSize - grid.CellSize / 2f
          );

          Gizmos.DrawWireCube(cellPos, Vector3.one * grid.CellSize);
        }
      }

      Gizmos.color = Color.red;
      Gizmos.DrawSphere(grid.StartPosition, grid.CellSize * 0.1f);
    }
  }
}