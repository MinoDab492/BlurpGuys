using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballforward : MonoBehaviour
{

    public Rigidbody rb;
    public float speed, speed2;

    // Start is called before the first frame update

    public void Awake()
    {
       
    }


    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.back * speed2);
    }
    // Update is called once per frame
    void Update()
    {
       // StartCoroutine(mass());
        rb.AddForce(Vector3.back * speed * Time.deltaTime);

    }

    IEnumerator mass()
    {
        rb.mass = 0.1f;
        yield return new WaitForSeconds(0.5f);
        rb.mass = 1;
    }
}
