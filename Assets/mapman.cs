using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class mapman : MonoBehaviourPunCallbacks
{
  
    public void Map1()
    {

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(2);
        }

       
    }

    public void Map2()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(3);
        }
        
    }
    public void Map3()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(4);
        }
        
    }
    public void Map4()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(5);
        }
       

    }
    public void Map5()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(6);
        }


    }


}
