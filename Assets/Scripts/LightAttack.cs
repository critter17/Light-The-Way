using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.HurtEnemy();
        }
    }
}
