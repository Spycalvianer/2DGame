using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDetection : MonoBehaviour
{
    ChatGPTEnemyTest enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<ChatGPTEnemyTest>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.gameObject.activeSelf == true)
        {
            enemy.pursuingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy.pursuingPlayer = false;
    }
}
