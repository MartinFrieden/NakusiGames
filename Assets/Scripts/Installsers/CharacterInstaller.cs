using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class CharacterInstaller : Installer<CharacterInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<CharacterTunables>().AsSingle();
        Container.BindInterfacesAndSelfTo<CharacterStateManager>().AsSingle();
        Container.Bind<CharacterStateMove>().AsSingle();

        Container.BindInterfacesAndSelfTo<CharacterDeathHandler>().AsSingle();
        
    }
}
