using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMove : ICharacterState
{
    readonly Settings _settings;
    readonly CharacterView _view;
    //readonly CharacterMoveHandler _moveHandler;

    Vector3 _target;

    public CharacterStateMove(CharacterView view,
                              Settings settings)
                              //CharacterMoveHandler moveHandler)
    {
        _settings = settings;
        //_moveHandler = moveHandler;
        _view = view;
    }

    public void EnterState()
    {
        _target = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        _view.MoveCharacter(_target);
    }

    public void ExitState()
    {
    }

    public void Update()
    {

    }

    public void FixedUpdate()
    {
        if (_view.ReminingDistance <= 0.5f)
        {
            _target = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            _view.MoveCharacter(_target);
        }
    }

    [System.Serializable]
    public class Settings
    {

    }
   
}
