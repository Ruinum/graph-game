using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Audio;

namespace Ruinum.ECS.Systems.Features
{
    public class AudioSystems : Feature
    {
        public AudioSystems(Contexts contexts, IGameServices services)
        {
            Add(new AudioPlaySystem(contexts.game, services.Audio));
            Add(new AudioDestroySystem(contexts.game));
        }
    }
}