using Industry;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Project.Installer
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private BuildingCountingService buildingService;
        [SerializeField] private MovementSettings _movementSettings;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private ResourceCount _count;
        [SerializeField] private PowerService _powerService;

        public override void InstallBindings()
        {
            Container.Bind<BuildingCountingService>().FromInstance(buildingService).AsCached();
            Container.Bind<ResourceCount>().FromInstance(_count).AsSingle();
            Container.Bind<MovementSettings>().FromInstance(_movementSettings).AsSingle();
            Container.Bind<Inventory>().FromInstance(_inventory).AsSingle();
            Container.Bind<PowerService>().FromInstance(_powerService).AsSingle();
        }
    }
}
