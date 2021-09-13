using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum BombType
{
    EasyBomb,
    PowerBomb
}
public class Bomb : MonoBehaviour, IPoolable<float, float, BombType, IMemoryPool>
{
    float _startTime;
    BombType _type;
    float _speed;
    float _lifeTime;

    [SerializeField]
    MeshRenderer _renderer = null;
    [SerializeField]
    Material _easyBombMat = null;
    [SerializeField]
    Material _powerBombMat = null;

    IMemoryPool _pool;

    public BombType Type
    {
        get { return _type; }
    }

    public void OnTriggerEnter(Collider other)
    {
        //BANG
        Debug.Log("BANG");
    }

    public void Update()
    {
        if (Time.realtimeSinceStartup - _startTime > _lifeTime)
        {
            _pool.Despawn(this);
        }
    }

    public void OnSpawned(float speed, float lifeTime, BombType type, IMemoryPool pool)
    {
        _pool = pool;
        _type = type;
        _speed = speed;
        _lifeTime = lifeTime;
        _renderer.material = type == BombType.EasyBomb ? _easyBombMat : _powerBombMat;
        _startTime = Time.realtimeSinceStartup;
    }

    public void OnDespawned()
    {
        _pool = null;
    }

    public class Factory : PlaceholderFactory<float, float, BombType, Bomb>
    {

    }
}
