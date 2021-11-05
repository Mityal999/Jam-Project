using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackItem : MonoBehaviour
{
    public float maxDamage;
    public float timeToDamage;
    public float rotationToHit;

    public Transform itemRotationCenterTransform;

    private Quaternion startRotation;
    private bool isAttacking = false;
    private float currentDamageMultiplier = 1;



    public float GetCurrentDamage()
    {
        return currentDamageMultiplier * maxDamage;
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
            StartAttack();
        }
    }

    public void StartAttack()
    {
        startRotation = itemRotationCenterTransform.rotation;
        StartCoroutine("Sway");
    }

    public IEnumerator Sway()
    {
        float endYRot = rotationToHit;
        float duration = timeToDamage;

        float t = 0;
        while (t < 1f)
        {
            t = Mathf.Min(1f, t + Time.deltaTime / duration);
            currentDamageMultiplier = t;
            Vector3 newEulerOffset = Vector3.up * (endYRot * t*t);

            itemRotationCenterTransform.rotation = startRotation * Quaternion.Euler(newEulerOffset);

            yield return null;
        }

        EndAttack();
    }

    private void EndAttack()
    {
        itemRotationCenterTransform.rotation = startRotation;
        isAttacking = false;
    }



}
