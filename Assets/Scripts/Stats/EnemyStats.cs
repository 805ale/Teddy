using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    // Start is called before the first frame update
    public override void Die()
    {
        base.Die();

        // death animation + loot maybe

        Destroy(gameObject);
    }
}

