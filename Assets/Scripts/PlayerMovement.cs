using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    int coinsCollected = 0;
    bool notOnSticky = true;
    Transform camera;
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
        Time.fixedDeltaTime = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        //this method creates automatic stop because input goes to zero, if you'd like to use the approach below but have natural deceleration
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        /*
        float horizontal = Input.GetAxis("Horizontal Pan");
        float vertical = Input.GetAxis("Vertical Pan");
        Camera cam = rb.GetComponentInChildren<Camera>();
        //assume x = 5, y = 50 is 0,0
        float curr_y = cam.transform.rotation.eulerAngles.y;
        float curr_x = cam.transform.rotation.eulerAngles.x;
        if (horizontal < 0  || horizontal > 0 )
        {
            cam.transform.Rotate(new Vector3(0, horizontal * 0.5f, 0));
        }
        if (vertical < 0  || vertical > 0 )
        {
            cam.transform.Rotate(new Vector3(-vertical * 0.5f, 0, 0));
        }
        */
        rb.velocity = new Vector3(horizontalinput * speed, rb.velocity.y, verticalinput * speed);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
             Jump();
        }
        if (Input.GetButtonDown("Crouch") && notOnSticky)
        {
            Crouch();
        }
        if (Input.GetButtonUp("Crouch") && notOnSticky)
        {
            Uncrouch();
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
        jumpSound.volume = AudioManager.volume;
        if (AudioManager.soundFX)
            jumpSound.Play();
    }
    void Crouch()
    {
        //camera = transform.GetChild(0);
        //camera.SetParent(null);
        transform.Rotate(90 , 0, 0, Space.World);
    }
    void Uncrouch()
    {
        transform.Rotate(-90, 0, 0, Space.World);
        //camera.SetParent(transform);
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
        if (collision.gameObject.GetComponent<StickyPlatform>() != null)
        {
            notOnSticky = false;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<StickyPlatform>() != null)
        {
            notOnSticky = true;
        }
    }
    void Collect(GameObject coin) { 
        coin.GetComponent<MeshRenderer>().enabled = false;
        Destroy(coin);
        coinsCollected += 1;
        coinsText.text = "Coins: " + coinsCollected;
        coinSound.volume = AudioManager.volume;
        if (AudioManager.soundFX)
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
