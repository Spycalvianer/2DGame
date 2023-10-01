using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 offset;
    public Vector3 horizontalOffset;
    public float cameraSpeed;

    private void LateUpdate()
    {
        NormalFollow();
    }
    void HorizontalOffsetFollow()
    {
        transform.position = Vector3.Lerp(transform.position, ((playerPosition.position + offset) + horizontalOffset * playerPosition.localScale.x), Time.deltaTime * cameraSpeed);
    }
    void NormalFollow()
    {
        transform.position = playerPosition.position + offset;
    }
}
