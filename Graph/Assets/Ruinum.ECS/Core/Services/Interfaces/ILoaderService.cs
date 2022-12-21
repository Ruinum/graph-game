namespace Ruinum.ECS.Services.Interfaces
{
    public interface ILoaderService : IInitializableService
    {
        bool IsActive { get; set; }
        void UpdateProgress(float progress);
    }
}