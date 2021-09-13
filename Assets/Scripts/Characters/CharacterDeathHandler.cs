using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterDeathHandler 
{
    readonly CharacterFacade _facade;
    readonly SignalBus _signalBus;
    readonly Settings _settings;
    readonly CharacterView _view;

    public CharacterDeathHandler(CharacterView view,
        Settings settings,
        SignalBus signalBus,
        CharacterFacade facade)
    {
        _facade = facade;
        _signalBus = signalBus;
        _settings = settings;
        _view = view;
    }

    public void Die()
    {
        _signalBus.Fire<CharacterKilledSignal>();
        _facade.Dispose();
    }

    [SerializeField]
    public class Settings
    {

    }
}
