using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    int coinsCollected = 0;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] TMP_Text coinsText;
    [SerializeField] AudioSource coinSound;
    [SerializeField] AudioSource jumpSound;
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
        float horizontal = Input.GetAxis("Horizontal Pan");
        float vertical = Input.GetAxis("Vertical Pan");
        Camera cam = rb.GetComponentInChildren<Camera>();
        if (horizontal != 0) {
            cam.transform.Rotate(new Vector3(horizontal * 5f, 0, 0));
        }
        if (vertical != 0)
        {
            cam.transform.Rotate(new Vector3(0, vertical * 5f, 0));
        }
        rb.velocity = new Vector3(horizontalinput * speed, rb.velocity.y, verticalinput * speed);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        /*
        //if (Input.GetKeyDown(KeyCode.Space))

       if (Input.GetKey(KeyCode.A))
       {
            cam.transform.Rotate(new Vector3(cam.transform.rotation.x, -0.1f + cam.transform.rotation.y, cam.transform.rotation.z));
            Debug.Log("Move Forward (X-)");
       }
       if(Input.GetKey(KeyCode.D))
       {
           Debug.Log("Move Backward (X+)");
            cam.transform.Rotate(new Vector3(cam.transform.rotation.x, 0.1f + cam.transform.rotation.y, cam.transform.rotation.z));
        }
       if(Input.GetKey(KeyCode.W))
       {
           Debug.Log("Move Left (X-)");
            cam.transform.Rotate(new Vector3(-0.1f + cam.transform.rotation.x, cam.transform.rotation.y, cam.transform.rotation.z));
        }
       else if(Input.GetKey(KeyCode.S))
       {
           Debug.Log("Move Right (X+)");
            cam.transform.Rotate(new Vector3(0.1f + cam.transform.rotation.x, cam.transform.rotation.y, cam.transform.rotation.z));
        }
        */
    }
    void Jump() {
        GetComponent<Rigidbody>().velocity = new Vector3(rb.velocity.x, speed, rb.velocity.z);
        jumpSound.Play();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Weakness"))
        {
            Kill(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Collect(collision.gameObject);
        }
    }
    void Collect(GameObject coin) { 
        coin.GetComponent<MeshRenderer>().enabled = false;
        Destroy(coin);
        coinsCollected += 1;
        coinsText.text = "Coins: " + coinsCollected;
        coinSound.Play();
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
