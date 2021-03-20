using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;

public class LobbyManagerScript : MonoBehaviourPunCallbacks
{
    public GameObject RoomParent;
    public GameObject RoomElementPrefab;

    public Text InfoText;


    void Awake() {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void GetRooms(List<RoomInfo> roomInfo) {
        if (roomInfo == null || roomInfo.Count == 0) return;

        for(int i = 0; i < roomInfo.Count; i++) {
            GameObject RoomElement = GameObject.Instantiate(RoomElementPrefab);
            RoomElement.transform.SetParent(RoomParent.transform);
            RoomElement.GetComponent<RoomElementScript>().SetRoomInfo(roomInfo[i].Name);
        }
    }

    public static void DestroyChildObject(Transform parent_trans) {
        for(int i = 0; i < parent_trans.childCount; i++) {
            GameObject.Destroy(parent_trans.GetChild(i).gameObject);
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        Debug.Log("OnRoomListUpdate");
        DestroyChildObject(RoomParent.transform);
        GetRooms(roomList);
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        Debug.Log("OnJoinedLobby");
    }

    public override void OnCreatedRoom() {
        PhotonNetwork.LoadLevel("Connected");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
