using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBomb : BaseBomb
{
    
    [SerializeField] int powerBombDamage;
    public override int Damage { get { return powerBombDamage; } set { Damage = powerBombDamage; } }

    public override void Explosion()
    {
        Debug.Log("PowerBang with " + Damage);
       
    }
}
