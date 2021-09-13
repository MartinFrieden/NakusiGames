using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBomb : BaseBomb
{
    [SerializeField] int easyBombDamage;
    public override int Damage { get { return easyBombDamage; } set { Damage = easyBombDamage; } }

    public override void Explosion()
    {
        Debug.Log("EasyBang with "+ Damage);
       
    }
}
