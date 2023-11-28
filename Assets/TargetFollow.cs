using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            transform.position = Vector3.zero;
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
      
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            transform.position = target.position + offset;
       
    }
}
