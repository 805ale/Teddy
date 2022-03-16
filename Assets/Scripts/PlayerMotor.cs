using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    CharacterStats stats;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(target != null)
        {
            if (target != null)
            {
                agent.SetDestination(target.position);
                FaceTarget();
            }
        }
    }
    public void MoveToPoint (Vector3 point)
    {
        agent.SetDestination(point);
        agent.speed = 7f;
    }

    public void DashToPoint(Vector3 point)
    {
        agent.SetDestination(point);
        agent.speed = 150f;
        agent.stoppingDistance = 5f;
       

    }
    
    

    public void FollowTarget (Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void ReduceSpeed()
    {
        agent.speed = 7;
    }
}
