using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float initialHp;
    public float immunityTime;
    public float chaseDistance;

    public GameObject playerObj;

    public bool isImmune = false;

    private NavMeshAgent agent;
    public float currentHp;
    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        currentHp = initialHp;
    }


    private void Update()
    {
        //Рассчитать расстояние до игрока и преследовать его, если оно мало
        float distanceToPlayer = (playerObj.transform.position - gameObject.transform.position).magnitude;
        if (distanceToPlayer < chaseDistance)
        {
            agent.SetDestination(playerObj.transform.position);
        }
    }

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

    private void Die()
    {
        Destroy(gameObject);
    }


}
