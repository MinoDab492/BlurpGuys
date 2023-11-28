using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class PlayersManagerContoller : MonoBehaviour
{
    public Transform[] spawnPoints;

    PhotonView pv;

    void Awake()
    {
        pv = GetComponent<PhotonView>();

        Player[] players = PhotonNetwork.PlayerList;

        if (!pv.IsMine)
            return;

        for (int i = 0; i < players.Length; i++)
        {
            pv.RPC("StartGame", players[i], spawnPoints[i].position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    [PunRPC]

    public void StartGame(Vector3 spawnPos, Quaternion spawnRot)
    {
        PhotonNetwork.Instantiate("Player1", spawnPos, spawnRot,0);
    }

    

}
