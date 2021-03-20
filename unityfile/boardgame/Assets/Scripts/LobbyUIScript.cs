using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyUIScript : MonoBehaviour {
    public Button OpenRoomPanelButton;
    public GameObject CreateRoomPanel;
    public Text RoomNameText;
    public Button CreateRoomButton;


    public void OnClick_OpenRoomPanelButton() {
        if (CreateRoomPanel.activeSelf) {
            CreateRoomPanel.SetActive(false);
        } else {
            CreateRoomPanel.SetActive(true);
        }
    }

    public void OnClick_CreateRoomButton() {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        if (string.IsNullOrEmpty(RoomNameText.text)) {
            RoomNameText.text = "MyRoom";
        }

        PhotonNetwork.CreateRoom(RoomNameText.text, roomOptions, null);

    }


}