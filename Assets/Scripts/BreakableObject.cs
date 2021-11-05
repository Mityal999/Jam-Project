using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : FragileEntity
{
    private void Start()
    {
        currentHp = initialHp;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

}
