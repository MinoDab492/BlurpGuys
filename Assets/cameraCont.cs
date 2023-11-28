using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCont : MonoBehaviour
{

    public float minDist;
    public float maxDist;
    public float smnoot;
    Vector3 dollyDir;
    public Vector3 dollyDirAd;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 desired = transform.parent.TransformPoint(dollyDir * maxDist);

        RaycastHit hit;

        if(Physics.Linecast(transform.parent.position,desired,out hit))
        {
            distance = Mathf.Clamp(hit.distance, minDist, maxDist);

        }
        else
        {
            distance = maxDist;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smnoot);
    }
}
