using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargetting : MonoBehaviour
{
    float moveSpeed = 10f;
    Rigidbody rb;
    GameObject player;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(gameObject, 3f);
    }
}
