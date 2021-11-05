using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FragileEntity : MonoBehaviour
{
    public float initialHp;
    public float currentHp;

    public float immunityTime;
    public bool isImmune = false;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            MeleeAttackItem attackItem = other.gameObject.GetComponentInParent<MeleeAttackItem>();
            float damageToRecieve = attackItem.GetCurrentDamage();
            TryRecieveDamage(damageToRecieve);
        }
    }

    private void TryRecieveDamage(float damage)
    {
        if (isImmune)
        {
            //do nothing
        }
        else
        {
            RecieveDamage(damage);
        }
    }
    private void RecieveDamage(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
        else
        {
            isImmune = true;
            StartCoroutine("ImmunityTimer");
        }

    }

    public IEnumerator ImmunityTimer()
    {
        yield return new WaitForSeconds(immunityTime);

        isImmune = false;
    }

    public abstract void Die();
}
