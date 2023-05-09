namespace Ruinum.ECS.Core.Configurations.Game.Strategies
{
    public class SimpleAudioConfigStrategy : IAudioConfigStrategy
    {
        public AudioConfig AudioConfig;
        public bool TryGet(GameEntity entity, out AudioConfig result)
        {
            result = AudioConfig;
            return true;
        }
    }
}
