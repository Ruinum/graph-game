using Ruinum.ECS.Services;
using Ruinum.ECS.Services.Interfaces;
using Ruinum.ECS.Systems.Features;

using System;
using System.Threading.Tasks;

using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ruinum.ECS
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private InputActionAsset _input;
        private Feature _systems;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private async void Start()
        {
            DontDestroyOnLoad(gameObject);

            LogDeviceInfo();

            var services = new RuinumServices(new ConfigService(), 
                new AssetService(),
                new EntityIndexService(Contexts.sharedInstance),
                new LoaderService(),
                new SceneService(),
                new InputService(_input),
                new AudioService());

            _systems = new Feature("Empty");

            await PreInitializeServices(services.Loader, services.Config);

            ConfigInitializer.Initialize(Contexts.sharedInstance, services);

            _systems = new RuinumSystems(Contexts.sharedInstance, services);
            _systems.Initialize();

            services.Config.SharedConfig.MainEntity.Create();

            await PostInitializeServices(services.Loader, services.Config);


#if !ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR
            DontDestroyOnLoad(_systems.gameObject);
#endif
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private void OnDestroy()
        {
            _systems.TearDown();
            _systems.ClearReactiveSystems();
            _systems.Cleanup();
#if UNITY_EDITOR
            EditorUtility.UnloadUnusedAssetsImmediate();
            GC.Collect();
            GC.WaitForPendingFinalizers();
#endif
        }

        private static void LogDeviceInfo()
        {
#if !UNITY_EDITOR
            LogSystem.Log($"OS Version: {SystemInfo.operatingSystem}");
            LogSystem.Log($"Processor type: {SystemInfo.processorType} {(Environment.Is64BitProcess ? "x86_64" : "x86")}, ProcessorCount: {SystemInfo.processorCount}");
            LogSystem.Log($"MemorySize: {SystemInfo.systemMemorySize}");
            LogSystem.Log($"Graphic Device: {SystemInfo.graphicsDeviceName} ({SystemInfo.graphicsDeviceVersion}) Graphic Memory: {SystemInfo.graphicsMemorySize} Graphic Max TexSize: {SystemInfo.maxTextureSize}");
#endif
        }

        private static async Task PostInitializeServices(params IInitializableService[] services)
        {
            foreach (var service in services)
            {
                await service.PostInitializeAsync();
            }
        }

        private static async Task PreInitializeServices(params IInitializableService[] services)
        {
            foreach (var service in services)
            {
                await service.PreInitializeAsync();
            }
        }
    }
}