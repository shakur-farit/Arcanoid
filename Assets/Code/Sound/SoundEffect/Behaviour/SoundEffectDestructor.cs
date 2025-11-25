using System.Threading;
using Code.Gameplay.ObjectPool.Service;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.States.GameStates
{
  public class SoundEffectDestructor : MonoBehaviour
  {
    [SerializeField] private SoundEffectItem _item;

    private CancellationTokenSource _cts;

    private IObjectPoolService _objectPool;

    [Inject]
    public void Constructor(IObjectPoolService objectPool) => 
      _objectPool = objectPool;

    private void OnDestroy() => 
      _cts?.Cancel();

    public async UniTask Destruct(int destructDelay)
    {
      _cts = new CancellationTokenSource();

      try
      {
        await UniTask.Delay(destructDelay, cancellationToken: _cts.Token);
      }
      catch
      {
        return;
      }

      _objectPool.Return(_item.ViewPrefab, gameObject);
    }
  }
}