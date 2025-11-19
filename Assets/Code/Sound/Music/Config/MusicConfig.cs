using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  [CreateAssetMenu(menuName = "Arcanoid/Music Config", fileName = "MusicConfig")]
  public class MusicConfig : ScriptableObject
  {
    public MusicTypeId TypeId;
    public AudioClip AudioClip;
    [Range(0f, 1f)] public float Volume;
  }
}