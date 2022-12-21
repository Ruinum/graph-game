using System.Threading.Tasks;

namespace Ruinum.ECS.Services.Interfaces
{
    public interface IInitializableService
    {
        Task PostInitializeAsync();

        Task PreInitializeAsync();
    }
}