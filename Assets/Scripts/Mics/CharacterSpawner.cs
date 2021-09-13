using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class CharacterSpawner : ITickable, IInitializable
{
    readonly CharacterFacade.Factory _characterFactory;
    readonly SignalBus _signalBus;
    readonly Settings _settings;

    float _desiredNumCharacters;
    int _characterCount;
    float _lastSpawnTime;

    public CharacterSpawner(
        Settings settings,
        SignalBus signalBus,
        CharacterFacade.Factory characterFactory)
    {
        _characterFactory = characterFactory;
        _signalBus = signalBus;
        _settings = settings;
        _desiredNumCharacters = settings.NumCharactersStartAmount;
    }

    public void Initialize()
    {
        _signalBus.Subscribe<CharacterKilledSignal>(OnCharacterKilled);
    }

    void OnCharacterKilled()
    {
        _characterCount--;
    }

    public void Tick()
    {
        _desiredNumCharacters += _settings.NumCharactersIncreaseRate * Time.deltaTime;
        if (_characterCount < (int)_desiredNumCharacters && 
            Time.realtimeSinceStartup - _lastSpawnTime > _settings.MinDelayBetweenSpawns)
        {
            SpawnCharacter();
            _characterCount++;
        }
    }

    void SpawnCharacter()
    {
        float speed = Random.Range(_settings.SpeedMin, _settings.SpeedMax);
        float accuracy = Random.Range(_settings.AccuracyMin, _settings.AccuracyMax);

        var characterFacade = _characterFactory.Create(accuracy, speed);
        characterFacade.Position = ChooseRandomStartPosition();

        _lastSpawnTime = Time.realtimeSinceStartup;
    }

    Vector3 ChooseRandomStartPosition()
    {
        return new Vector3Int(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }

    [System.Serializable]
    public class Settings
    {
        public float SpeedMin;
        public float SpeedMax;

        public float AccuracyMin;
        public float AccuracyMax;

        public float NumCharactersIncreaseRate;
        public float NumCharactersStartAmount;

        public float MinDelayBetweenSpawns = 0.5f;
    }
}
