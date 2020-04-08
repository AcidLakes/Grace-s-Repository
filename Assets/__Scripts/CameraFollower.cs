using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 targetPos;
    
    void FixedUpdate()
    {
        targetPos = new Vector3(target.position.x, 0, target.position.z);
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(targetPos, desiredPosition, smoothSpeed);
        transform.position= desiredPosition;
        transform.LookAt(targetPos);
    }
}
