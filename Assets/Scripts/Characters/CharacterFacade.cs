using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
public class CharacterFacade : MonoBehaviour, IPoolable<float,float, IMemoryPool>, IDisposable
{
    [SerializeField] Image HealthBar;
    CharacterView _view;
    CharacterTunables _tunables;
    CharacterDeathHandler _deathHandler;
    CharacterStateManager _stateManager;
    CharacterRegistry _registry;
    IMemoryPool _pool;
    [SerializeField] float _health = 100.0f;

    [Inject]
    public void Construct(CharacterView view,
        CharacterTunables tunables,
        CharacterDeathHandler deathHandler,
        CharacterStateManager stateManager,
        CharacterRegistry registry)
    {
        _view = view;
        _tunables = tunables;
        _deathHandler = deathHandler;
        _stateManager = stateManager;
        _registry = registry;
    }

    public CharacterStates State
    {
        get { return _stateManager.CurrentState; }
    }

    public bool IsDead
    {
        get; set;
    }

    public float Health
    {
        get { return _health; }
    }

    public float Accuracy
    {
        get { return _tunables.Accuracy; }
    }

    public float Speed
    {
        get { return _tunables.Speed; }
    }

    public void Dispose()
    {
        _pool.Despawn(this);
    }

    public Vector3 Position
    {
        get { return _view.Position; }
        set { _view.Position = value; }
    }

    public void Die()
    {
        _deathHandler.Die();
    }

    public void OnDespawned()
    {
        _registry.RemoveCharacter(this);
        _pool = null;
    }

    public void OnSpawned(float accuracy, float speed, IMemoryPool pool)
    {
        _health = 100;
        _pool = pool;
        _tunables.Accuracy = accuracy;
        _tunables.Speed = speed;
        _registry.AddCharacter(this);
        HealthBar.fillAmount = Health / 100;
    }

    private void Update()
    {
        HealthBar.fillAmount = Health / 100;
    }

    public void TakeDamage(float healthLoss)
    {
        _health = Mathf.Max(0.0f, _health - healthLoss);
        if (_health <= 0)
        {
            Die();
        }
    }

    public class Factory : PlaceholderFactory<float, float, CharacterFacade>
    {

    }


}
