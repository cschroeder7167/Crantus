using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICode : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 walkPoint;
    bool walkPointSet;
    public bool playerIsDead;
    public float walkPointRange;
    public float attackTime;
    bool attacked;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public bool playerisDead = false;
    void Awake()
        {
            player = GameObject.Find("Player").transform;
            agent = GetComponent<NavMeshAgent>();

        }


    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        if (!playerInSightRange && !playerInAttackRange) Patrol();
        if (playerInSightRange && !playerInAttackRange) Chase();
        if (playerInAttackRange && playerInSightRange) Kill();
    }

    void Patrol()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }
    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
        
    }

    void Chase()
    {
        agent.SetDestination(player.position);

    }

    void Kill()
    {
        playerIsDead = true;

    }


}
