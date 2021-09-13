using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRegistry
{
    readonly List<CharacterFacade> _characters = new List<CharacterFacade>();

    public IEnumerable<CharacterFacade> Characters
    {
        get { return _characters; }
    }

    public void AddCharacter(CharacterFacade character)
    {
        _characters.Add(character);
    }

    public void RemoveCharacter(CharacterFacade character)
    {
        _characters.Remove(character);
    }
}

