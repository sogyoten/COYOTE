using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomElementScript : MonoBehaviour
{

    //for UI output
    public Text RoomName;

    private string roomname;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRoomInfo(string _RoomName) {
        roomname = _RoomName;
        RoomName.text = "Room:" + _RoomName;
    }

    public void OnJoinRoomButton() {
        PhotonNetwork.JoinRoom(roomname);
    }
}
