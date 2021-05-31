using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject[] waypoints;
    int current;
    public float speed = 1f;
    float wpRadius = 1f;

    private void Update()
    {
        if(Vector3.Distance(waypoints[current].transform.position, transform.position) < wpRadius)
        {
            current++;
            if(current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }

}