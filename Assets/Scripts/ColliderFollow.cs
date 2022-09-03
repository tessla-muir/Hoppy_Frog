using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFollow : MonoBehaviour
{
    public Transform target;
    public float targetOffset = 7f;

    private void LateUpdate() 
    {
        if (target.position.y > transform.position.y) {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y - targetOffset, transform.position.z);
            transform.position = newPos;
       }
    }
}
