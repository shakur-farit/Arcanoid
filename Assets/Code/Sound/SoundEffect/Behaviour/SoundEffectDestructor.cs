using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class SoundEffectDestructor : MonoBehaviour
  {
    private CancellationTokenSource _cts;

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

      Destroy(gameObject);
    }
  }
}