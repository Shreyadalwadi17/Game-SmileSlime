using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float offset;
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 targetPos= new Vector3(target.transform.position.x+offset , target.transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}