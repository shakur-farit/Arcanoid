namespace Code.Infrastructure.States.GameStates
{
  public interface ISoundEffectFactory
  {
    void CreateSoundEffect(SoundEffectTypeId typeId);
  }
}