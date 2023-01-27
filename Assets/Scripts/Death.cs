using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    private void Update()
    {
        if (transform.position.y < -40)
        {
            ReloadLevel();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Enemy Weakness"))
        {
            Kill(collision.gameObject);
        }
    }
    void Kill(GameObject enemyWeakness)
    {
        Destroy(enemyWeakness.transform.parent.gameObject);
        //fullEnemy.SetActive(false);
        //enemyWeakness.SetActive(false);
    }
    void Die() {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        Invoke(nameof(ReloadLevel), 3f);
    }
    void ReloadLevel() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        deathSound.Play();
    }
}
