using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //this method creates automatic stop because input goes to zero, if you'd like to use the approach below but have natural deceleration
        //use GetAxisRaw
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalinput * speed, rb.velocity.y, verticalinput * speed);
        //if (Input.GetKeyDown(KeyCode.Space))
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        /*this method allows physics based deceleration to zero
       if (Input.GetKey(KeyCode.UpArrow))
       {
           Debug.Log("Move Forward (Z+)");
           rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
       }
       if(Input.GetKey(KeyCode.DownArrow))
       {
           Debug.Log("Move Backward (Z-)");
           rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
       }
       if(Input.GetKey(KeyCode.LeftArrow))
       {
           Debug.Log("Move Left (X-)");
           rb.velocity = new Vector3( -speed, rb.velocity.y, rb.velocity.z);
       }
       else if(Input.GetKey(KeyCode.RightArrow))
       {
           Debug.Log("Move Right (X+)");
           rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
       }
       */
    }
    void Jump() {
        GetComponent<Rigidbody>().velocity = new Vector3(rb.velocity.x, speed, rb.velocity.z);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Weakness"))
        {
            Kill(collision.gameObject);
        }
    }
    void Kill(GameObject enemyWeakness)
    {
        Destroy(enemyWeakness.transform.parent.gameObject);
        Jump();
    }
    bool IsGrounded() {

        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}
