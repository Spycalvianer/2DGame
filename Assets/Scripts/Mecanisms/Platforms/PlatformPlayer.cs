using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayer : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform target;
    public float platformSpeed;
    public float timeToWait;

    private void Start()
    {
        target = pointB;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * platformSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            StartCoroutine(WaitForPlayer());
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            StopAllCoroutines();
            target = pointB;
            collision.transform.SetParent(null);
        }
    }
    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSeconds(timeToWait);
        target = pointA;
    }
}
