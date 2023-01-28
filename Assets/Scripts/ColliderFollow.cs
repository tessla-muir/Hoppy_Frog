using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFollow : MonoBehaviour
{
    public Transform target;
    float targetOffset = 7f;
    float playerHeight = 0;

    private void Update() 
    {
        // Update where death collider should be when player height updates
        if (playerHeight < target.position.y) 
        {
            playerHeight = target.position.y;
        }
    }

    private void LateUpdate() 
    {
        // Move death collider upwards
        if (target.position.y > transform.position.y) {
            Vector3 newPos = new Vector3(transform.position.x, playerHeight - targetOffset, transform.position.z);
            transform.position = newPos;
       }
    }
}
