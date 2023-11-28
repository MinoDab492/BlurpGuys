using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubes2Script : MonoBehaviour
{
    public  Vector3 pos1 = new Vector3(-4, 0, 0);
    public  Vector3 pos2 = new Vector3(4, 0, 0);

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}
