using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeCheckState : MeleeState
{
    [SerializeField] Transform target;

    [Header("Ranges")]
    [SerializeField] float aggroCheck;

    [Header("MoveSpeed")]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    [Header("Debug")]
    [SerializeField] bool showStateMessages;
    [SerializeField] bool debugAggroRange;

    [Header("References")]
    [SerializeField] MeleeEnemy mEnemy;
    [SerializeField] NavMeshAgent navMeshAgent;

    public override void EnterState()
    {
        if (showStateMessages)
            print("Enter Melee Enemy Check State");
    }

    public override void Tick()
    {
        LookAtTarget();
        CheckAction();
    }

    void LookAtTarget()
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.parent.position.y, target.position.z);
        transform.parent.LookAt(targetPos);
    }

    void CheckAction()
    {
        // attack if player is within range
        if (Vector3.Distance(transform.position, target.position) <= mEnemy.AtkRange)
        {
            stateMachine.ChangeState<MeleeAttackState>();
        }

        // if player is outside of aggro check, walk towards player
        if (Vector3.Distance(transform.position, target.position) > aggroCheck)
        {
            navMeshAgent.speed = walkSpeed;
            navMeshAgent.SetDestination(target.position);
        }
        // if player is inside aggro check, run towards player
        else
        {
            navMeshAgent.speed = runSpeed;
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (debugAggroRange)
            Gizmos.DrawWireSphere(transform.position, aggroCheck);
        else
            Gizmos.DrawWireSphere(transform.position, mEnemy.AtkRange);
    }
}
