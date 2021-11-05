using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : FragileEntity
{
    public float chaseDistance;
    public float attackDistance;
    public GameObject playerObj;

    public MeleeAttackItem attackItem;

    private NavMeshAgent agent;



    private void Start()
    {
        currentHp = initialHp;

        agent = gameObject.GetComponent<NavMeshAgent>();
    }



    private void Update()
    {
        //Рассчитать расстояние до игрока и преследовать его, если оно мало
        float distanceToPlayer = (playerObj.transform.position - gameObject.transform.position).magnitude;
        if (distanceToPlayer < chaseDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(playerObj.transform.position);
        }
        if (distanceToPlayer < attackDistance)
        {
            agent.isStopped = true;
            attackItem.TryAttack();
        }

    }



    public override void Die()
    {
        Destroy(gameObject);
    }

}
