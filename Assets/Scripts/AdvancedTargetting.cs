using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedTargetting : MonoBehaviour
{
    float moveSpeed = 3f;
    Rigidbody rb;
    GameObject player;
    Vector3 moveDirection;
    float timestart;
    // Start is called before the first frame update
    void Start()
    {
        timestart = Time.time;
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        if (Time.time - timestart < 3f)
        {
            moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
            rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        }
    }
}
