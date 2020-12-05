using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [Header("Combat Settings")]
    [SerializeField] Transform playerTrans;
    [SerializeField] bool inAtkRange;

    [Header("References")]
    [SerializeField] MeleeSM stateMachine;

    private void Update()
    {
        // if player is in atk range still and atk speed cooldown is refreshed, attack again
    }

    void CheckIfTargetInAtkRange()
    {

    }

    public override void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(1);

        stateMachine.ChangeState<MeleeCheckState>();
    }

    protected override void Die()
    {
        stateMachine.ChangeState<MeleeDeathState>();
    }
}
