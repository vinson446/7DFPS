using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : MeleeState
{
    [SerializeField] MeleeEnemy mEnemy;

    [Header("Debug")]
    [SerializeField] bool showStateMessages;

    public override void EnterState()
    {
        if (showStateMessages)
            print("Enter Melee Enemy Attack State");
        mEnemy.Attack();
    }
}
