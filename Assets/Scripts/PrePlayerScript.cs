using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrePlayerScript : MonoBehaviour
{
    public MeleeAttackItem attackItem;



    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            attackItem.TryAttack();
        }
    }

}
