using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Positions")]
    Transform target;
    public Transform pointA;
    public Transform pointB;
    EnemyDetection enemyDetect;
    public Transform playerPos;
    [Header("Variables")]
    public float movingSpeed;
    public float timer;
    public float maxWaitTime;
    public float pursuingSpeed;
    bool isResting;
    [HideInInspector] public bool playerDetected = false;
    private void Awake()
    {
        enemyDetect = GetComponent<EnemyDetection>();
    }
    private void Start()
    {
        target = pointA;
    }
    private void Update()
    {
        if(!playerDetected)Move();
    }
    void Move()
    {
        if(Vector2.Distance(target.position, transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, movingSpeed * Time.deltaTime);
        }
        else if(Vector2.Distance(target.position, transform.position) < 0.1f)
        {
            StartCoroutine(RestingAndMoveSequence());
        }
    }
    IEnumerator RestingAndMoveSequence()
    {
        isResting = true;
        yield return new WaitForSeconds(maxWaitTime);
        isResting = false;
        StartCoroutine(ChangeTarget());
        
    }
    private IEnumerator ChangeTarget()
    {
        if(target == pointA && !isResting)
        {
            target = pointB;
        }
        else if (target == pointB && !isResting)
        {
            target = pointA;
            
        }
        yield break;
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
    }
    void PursuitPlayer()
    {
        target = playerPos;
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, Time.deltaTime * pursuingSpeed);
    }
}
