using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance;

    public TMP_InputField roomName;
    public TMP_Text roomNameText;

    public Transform roomListCont;
    public GameObject roomListPref;

    public Transform playerListCont;
    public GameObject playerListPref;

    public GameObject button;

    public Button goButton;

    public TMP_InputField nickName;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void Update()
    {
        Cursor.visible = true;

        if(nickName.text.Length > 3)
        {
            goButton.interactable = true;
        }
        else
        {
            goButton.interactable = false;
        }
    }



    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {

        MenuManager.instance.OpenMenu("nick");
       
        Debug.Log("Nickname Menu Opened Succesfully");
       

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room Succesfully");
        
        MenuManager.instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        
        Player[] players = PhotonNetwork.PlayerList;

        foreach (Transform child in playerListCont)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerListPref, playerListCont).GetComponent<PlayerListitem>().SetUp(players[i]);
        }

        button.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        button.SetActive(PhotonNetwork.IsMasterClient);
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.instance.OpenMenu("loading");
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomName.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomName.text);
        MenuManager.instance.OpenMenu("loading");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in  roomListCont)
        {
            Destroy(trans.gameObject);
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
            {
                continue;
            }
            Instantiate(roomListPref, roomListCont).GetComponent<roomlistitem>().SetRoom(roomList[i]);
        }

       
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListPref, playerListCont).GetComponent<PlayerListitem>().SetUp(newPlayer);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.instance.OpenMenu("loading");
    }
    public override void OnLeftLobby()
    {
        MenuManager.instance.OpenMenu("title");
    }

    public void SetPlayerName()
    {
        PhotonNetwork.NickName = nickName.text;
        MenuManager.instance.OpenMenu("title");

    }

    public void MenuBack()
    {
        MenuManager.instance.OpenMenu("title");
    }
}
