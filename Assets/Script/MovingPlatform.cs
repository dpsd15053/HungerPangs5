using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] public Transform platform;
    [SerializeField] public Transform startPoint;
    [SerializeField] public Transform endPoint;
    [SerializeField] public float speed = 1.5f;
    int direction = 1;
    public void Update()
    {
        Vector2 target = currentMovementTarget();
         
        platform.position = Vector2.MoveTowards(platform.position, target, speed* Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;
        if(distance <= 0.1f) 
        {
            direction *= -1;
        }
    }
    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player")) 
        {
            
            other.transform.parent = platform;
        }
    }
}
