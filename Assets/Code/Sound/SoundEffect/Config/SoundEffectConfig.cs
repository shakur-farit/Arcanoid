using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  [CreateAssetMenu(menuName = "Arcanoid/Sound Effect Config", fileName = "SoundEffectConfig")]
  public class SoundEffectConfig : ScriptableObject
  {
    public SoundEffectTypeId TypeId;
    public GameObject ViewPrefab;
    public AudioClip AudioClip;
    public int Lifetime;
  }
}