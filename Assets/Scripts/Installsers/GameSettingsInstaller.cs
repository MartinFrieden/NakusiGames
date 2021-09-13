using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "TestNakusi/Game Settings")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public CharacterSpawner.Settings CharacterSpawner;
    public GameInstaller.Settings GameInstaller;
    public CharacterSettings Character;
    
    [System.Serializable]
    public class CharacterSettings
    {
        public CharacterTunables DefaultSettings;
        public CharacterStateMove.Settings CharacterStateMove;
        public CharacterDeathHandler.Settings CharacterDeathWatcher;
        public CharacterCommonSettings CharacterCommonSettings;
    }

    public override void InstallBindings()
    {
        Container.BindInstance(CharacterSpawner).IfNotBound();
        Container.BindInstance(GameInstaller).IfNotBound();
        Container.BindInstance(Character.CharacterStateMove).IfNotBound();
        Container.BindInstance(Character.CharacterDeathWatcher).IfNotBound();
        Container.BindInstance(Character.CharacterCommonSettings).IfNotBound();
    }
}
