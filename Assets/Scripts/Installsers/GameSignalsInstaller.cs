using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSignalsInstaller : Installer<GameSignalsInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<CharacterKilledSignal>();

        Container.BindSignal<CharacterKilledSignal>().ToMethod(() => Debug.Log("Fired CharacterKilledSignal"));
    }
}
