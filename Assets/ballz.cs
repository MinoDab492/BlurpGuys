using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballz : MonoBehaviour
{

    public GameObject balls;

    public float spawntime;
    public float timebtwaves;

    public Transform point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawntime += 0.01f;

        if (spawntime >= timebtwaves)
        {
            Instantiate(balls, point.transform.position, Quaternion.identity);
            spawntime = 0;
        }
    }

}
