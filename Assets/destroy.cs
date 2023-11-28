using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public GameObject[] cubes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                Instantiate(cubes[i], transform.position, Quaternion.identity);
            }

            
            Destroy(gameObject);
        }
    }
}
