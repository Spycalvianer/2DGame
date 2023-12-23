using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] Transform pointA, pointB;
    Transform target;
    bool isWaiting;
    [SerializeField] float movingSpeed, timeToWait;

    private void Start()
    {
        target = pointA;
    }
    private void Update()
    {
        Logic();
    }
    void Logic()
    {
        if (Vector2.Distance(target.position, transform.position) < 0.1f && !isWaiting)
        {
            StartCoroutine("Waiting");
        }
        else MovePlatform();
    }
    void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * movingSpeed);
    }
    void ChangeTarget()
    {
        if (target == pointA) target = pointB;
        else if (target == pointB) target = pointA;
    }
    IEnumerator Waiting()
    {
        isWaiting = true;
        yield return new WaitForSeconds(2f);
        ChangeTarget();
        isWaiting = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
