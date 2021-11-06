using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackItem : MonoBehaviour
{
    public float maxDamage;
    public float accelerationTime;

    private bool isAttacking = false;
    private HingeJoint hinge;
    private Rigidbody rb;


    public float GetCurrentDamage()
    {
        float currentDamageMultiplier = rb.velocity.magnitude / 10;

        return currentDamageMultiplier * maxDamage;
    }

    private void Start()
    {
        hinge = gameObject.GetComponent<HingeJoint>();
        rb = gameObject.GetComponent<Rigidbody>();
    }


    public void TryAttack()
    {
        if (isAttacking)
        {
            //do nothing
        }
        else
        {
            isAttacking = true;
            Attack();
        }
    }

    public void Attack()
    {
        StartCoroutine("Sway");
    }

    public IEnumerator Sway()
    {
        hinge.useSpring = false;
        hinge.useMotor = true;
        var motor = hinge.motor;

        yield return new WaitForSeconds(accelerationTime);

        hinge.useSpring = true;
        hinge.useMotor = false;

        EndAttack();
    }

    private void EndAttack()
    {
        isAttacking = false;
    }



}
