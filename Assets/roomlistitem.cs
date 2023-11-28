using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class roomlistitem : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    public RoomInfo info;

    public void  SetRoom(RoomInfo _info)
    {
        info = _info;
        text.text = _info.Name;
    }

    public void Onclic()
    {
        GameManager.instance.JoinRoom(info);
    }
}
