using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
        [Header("Positions")]
        public Transform pointA;
        public Transform pointB;
        private Transform currentTarget;
    public Transform playerPos;

        [Header("Variables")]
        public float movingSpeed;
        public float maxWaitTime;

        private float currentWaitTime;
        private bool isResting;
    [HideInInspector] public bool pursuingPlayer;
    public float pursueSpeed;

        private void Start()
        {
            currentTarget = pointA;
            isResting = false;
        }

        private void Update()
        {
            if (!isResting && !pursuingPlayer)
            {
                Move();
                Flip();
            }
            else if (pursuingPlayer)
            {
                PursuePlayer();
            }
        }

        void Move()
        {
            if (transform.position != currentTarget.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, movingSpeed * Time.deltaTime);
            }
            else
            {
                StartResting();
            }
        }

        void StartResting()
        {
            isResting = true;
            currentWaitTime = maxWaitTime;
            StartCoroutine(WaitAndChangeTarget());
        }

        IEnumerator WaitAndChangeTarget()
        {
            while (currentWaitTime > 0)
            {
                yield return new WaitForSeconds(1f);
                currentWaitTime--;
            }
            isResting = false;
        ChangeTarget();
    }

        void ChangeTarget()
        {
            if (currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            else
            {
                currentTarget = pointA;
            }
        }
    void Flip()
    { /*
        if (currentTarget == pointA)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else transform.localScale = new Vector2(1, transform.localScale.y);
        */
        if(transform.position.x - currentTarget.position.x < 0) transform.localScale = new Vector2(1, transform.localScale.y);
        else if (transform.position.x - currentTarget.position.x > 0) transform.localScale = new Vector2(-1, transform.localScale.y);
    }
    void PursuePlayer()
    {
        Vector3 targetPosition = new Vector3(playerPos.position.x, transform.position.y, transform.position.z);
        if(Vector2.Distance(transform.position, targetPosition) > 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * pursueSpeed);
        }
    }
}
