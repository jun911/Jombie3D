using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;

    public void AttackHitEvent()
    {
        if(target == null) { return;  }

        target.GetComponent<PlayerHealth>().TakeDamage(damage);

        Debug.Log("bang bang");
    }
}