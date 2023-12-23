using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDetection : MonoBehaviour
{
    EnemyPatrol enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<EnemyPatrol>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("playerDetected");
            enemy.pursuingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("PlayerEscaped");
        enemy.pursuingPlayer = false;
    }
}
