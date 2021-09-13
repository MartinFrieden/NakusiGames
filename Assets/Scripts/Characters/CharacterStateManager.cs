using ModestTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface ICharacterState
{
    void EnterState();
    void ExitState();
    void Update();
    void FixedUpdate();
}

public enum CharacterStates
{
    Walk,
    None
}

public class CharacterStateManager : ITickable, IFixedTickable, IInitializable
{
    ICharacterState _currentStateHandler;
    CharacterStates _currentState = CharacterStates.None;
    CharacterView _view;
    List<ICharacterState> _states;

    [Inject]
    public void Construct(CharacterView view,
                          CharacterStateMove move)
    {
        _view = view;
        _states = new List<ICharacterState>
        {
            move
        };
    }

    public CharacterStates CurrentState
    {
        get { return _currentState; }
    }

    public void Initialize()
    {
        Assert.IsEqual(_currentState, CharacterStates.None);
        Assert.IsNull(_currentStateHandler);
        ChangeState(CharacterStates.Walk);
    }

    public void ChangeState(CharacterStates state)
    {
        if (_currentState == state)
        {
            return;
        }

        _currentState = state;

        if (_currentStateHandler != null)
        {
            _currentStateHandler.ExitState();
            _currentStateHandler = null;
        }

        _currentStateHandler = _states[(int)state];
        _currentStateHandler.EnterState();
    }

    public void Tick()
    {
        _currentStateHandler.Update();
    }

    public void FixedTick()
    {
        _currentStateHandler.FixedUpdate();
    }
}
