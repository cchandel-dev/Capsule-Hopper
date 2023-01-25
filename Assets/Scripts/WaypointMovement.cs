using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] float speed;
    int nextIndex = 0;
    Transform body;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[nextIndex].position) < 0.1f)
            nextIndex = nextIndex == waypoints.Length - 1 ? 0 : nextIndex + 1;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextIndex].transform.position, speed*0.1f);
    }
}
