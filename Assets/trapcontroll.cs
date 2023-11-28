using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapcontroll : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.z > 492)
        {
            rb.AddForce(Vector3.back * speed);
        }else if (rb.position.z < 472)
        {
            rb.AddForce(Vector3.forward * speed);
        }
    }
}
