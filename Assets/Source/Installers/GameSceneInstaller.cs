using Industry;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Project.Installer
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] private MovementSettings _movementSettings;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private GameObject _factory�himney;
        [SerializeField] private ResourceCount _count;
        [SerializeField] private ObjectPool _pool;
        [SerializeField] private Joystick _joystick;

        public override void InstallBindings()
        {
            Container.Bind<ResourceCount>().FromInstance(_count).AsSingle();
            Container.Bind<MovementSettings>().FromInstance(_movementSettings).AsSingle();
            Container.Bind<Inventory>().FromInstance(_inventory).AsSingle();
            Container.Bind<GameObject>().FromInstance(_factory�himney).AsSingle();
            Container.Bind<ObjectPool>().FromInstance(_pool).AsSingle();
           Container.Bind<Joystick>().FromInstance(_joystick).AsSingle();
        }
    }
}
