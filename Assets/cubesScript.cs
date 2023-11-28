using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubesScript : MonoBehaviour
{
    public float min;
    public float max;

    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 4, max - min) + min, transform.position.y, transform.position.z);
    }
}
