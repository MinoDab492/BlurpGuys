using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;


    public void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;

        }

        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnEnable()
    {
        base.OnEnable();

        SceneManager.sceneLoaded += onSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= onSceneLoaded;
    }

    void onSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1)
        {
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefab", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
    }
}
