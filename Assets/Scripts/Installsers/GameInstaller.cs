using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject]
    Settings _settings = null;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<CharacterSpawner>().AsSingle();

        Container.BindFactory<float, float, CharacterFacade, CharacterFacade.Factory>()
            .FromPoolableMemoryPool<float, float, CharacterFacade, CharacterFacadePool>(poolBinder => poolBinder
             .WithInitialSize(5)
             .FromSubContainerResolve()
             .ByNewPrefabInstaller<CharacterInstaller>(_settings.CharacterFacadePrefab)
             .UnderTransformGroup("Characters"));

        Container.BindFactory<float, float, BombType, Bomb, Bomb.Factory>()
            .FromPoolableMemoryPool<float, float, BombType, Bomb, BombPool>(poolBinder => poolBinder
            .WithInitialSize(10)
            .FromComponentInNewPrefab(_settings.BombPrefab)
            .UnderTransformGroup("Bombs"));

        Container.Bind<CharacterRegistry>().AsSingle();
        GameSignalsInstaller.Install(Container);
    }

    [System.Serializable]
    public class Settings
    {
        public GameObject CharacterFacadePrefab;
        public GameObject BombPrefab;
    }

    class CharacterFacadePool : MonoPoolableMemoryPool<float,float,IMemoryPool,CharacterFacade>
    {

    }

    class BombPool : MonoPoolableMemoryPool<float, float, BombType, IMemoryPool, Bomb>
    {

    }
}
