using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speedx;
    [SerializeField] float speedy;
    [SerializeField] float speedz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(360 * speedx * Time.deltaTime, 360 * speedy * Time.deltaTime, 360 * speedz * Time.deltaTime);
    }
}
