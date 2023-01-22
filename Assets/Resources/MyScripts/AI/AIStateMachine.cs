using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateMachine : MonoBehaviour
{
    public enum AIState
    {
        Roaming,
        Chasing
    }
    [SerializeField] AIState state;
    [SerializeField] float speed;
    [SerializeField] float chaseDistance;
    [SerializeField] float attackDistance;
    Vector3 nextDestination;

    [SerializeField] Transform player;
    NavMeshAgent agent;
    
    [SerializeField] float xAxe;
    [SerializeField] float zAxe;

    void Start(){
        agent = GetComponent<NavMeshAgent>();
        GetRandomDirection();
    }

    void Update()
    {
        if (state == AIState.Roaming)
        {
            Roam();
        }
        else if (state == AIState.Chasing)
        {
            Chase();
        }
    }

    void Roam(){
    float distanceToDestination = Vector3.Distance(transform.position, nextDestination);
    float distanceToPlayer = Vector3.Distance(transform.position, player.position);

    if (distanceToPlayer <= chaseDistance)
    {
        state = AIState.Chasing;
    }
    if(agent.hasPath && agent.remainingDistance <= agent.stoppingDistance)
    {
    GetRandomDirection();
    }
    else
    {
    agent.SetDestination(nextDestination);
    }
}

void Chase()
{
    float distance = Vector3.Distance(transform.position, player.position);
    if (distance <= attackDistance)
    {
        Attack();
    }
    else if (distance > attackDistance && distance <= chaseDistance)
    {
        agent.SetDestination(player.position);
    }else {
        state = AIState.Roaming;
        agent.speed = speed;
    }
}

    NavMeshHit hit;
void GetRandomDirection()
{
    bool isOnNavMesh = false;

    while(!isOnNavMesh){
    float x = Random.Range(-xAxe+transform.position.x, xAxe+transform.position.x);
    float z = Random.Range(-zAxe+transform.position.z, zAxe+transform.position.z);
    Vector3 point = new Vector3(x, 0, z);
    isOnNavMesh = NavMesh.SamplePosition(point, out hit, 5f, NavMesh.AllAreas);
    }
    nextDestination = hit.position;
    nextDestination.y = 0f;
}
void Attack(){
    Debug.Log("Is Attacking");
}
}
   
