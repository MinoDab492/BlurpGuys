using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerMan : MonoBehaviour
{
    PhotonView pv;

    void Awake()
    {
        pv = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
       // CreatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePlayer()
    {
       // PhotonNetwork.Instantiate(Path.Combine("PhotonPrefab", "Player1"), Vector3.zero, Quaternion.identity);
    }
}
