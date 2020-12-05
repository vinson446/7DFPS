using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("HP Settings")]
    [SerializeField] int currentHP;
    [SerializeField] int maximumHP;

    [Header("Combat Settings")]
    [SerializeField] int damage;

    [SerializeField] float atkSpeed;
    public float AtkSpeed => atkSpeed;

    [SerializeField] float atkRange;
    public float AtkRange => atkRange;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maximumHP;
    }

    public virtual void Attack()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die() 
    { 

    }
}
