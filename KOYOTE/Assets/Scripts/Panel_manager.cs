using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.Asteroids;


namespace nishida.KOYOTE {
    public class Panel_manager : MonoBehaviourPunCallbacks {

        [Header("ConnectPanel")]
        public GameObject ConnectPanel;
        public InputField PlayerNameInput;

        [Header("RoomSelectPanel")]
        public GameObject RoomSelectPanel;
        public InputField RoomNameInput;

        [Header("InsideRoomPanel")]
        public GameObject InsideRoomPanel;

        private string roomName;

        private void Awake() {
            PhotonNetwork.AutomaticallySyncScene = true;
            Screen.SetResolution(1600, 900, false, 60);
            if (PhotonNetwork.IsConnected) {
                PhotonNetwork.Disconnect();
            }
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        #region about photon

        public override void OnConnectedToMaster() {
            this.SetActivePanel(RoomSelectPanel.name);
        }

        public override void OnJoinedRoom() {
            this.SetActivePanel(InsideRoomPanel.name);
        }

        #endregion

        #region about button
        public void OnConnectButtonClicked() {
            string playerName = PlayerNameInput.text;

            if (!playerName.Equals("")) {
                PhotonNetwork.LocalPlayer.NickName = playerName;
                PhotonNetwork.ConnectUsingSettings();
            } else {
                Debug.LogError("Player Name is invalid.");
            }

        }

        public void OnRoomCreateButtonClicked() {
            roomName = RoomNameInput.text;
            //roomName = (roomName.Equals(string.Empty)) ? "Room " + Random.Range(1000, 10000) : roomName;
            if (roomName.Equals(string.Empty)) {
                return;
            }

            RoomOptions options = new RoomOptions { MaxPlayers = 10 };
            //TypedLobby typedLobby=new TypedLobby
            PhotonNetwork.CreateRoom(roomName, options);
        }



        #endregion


        public void SetActivePanel(string activePanel) {
            ConnectPanel.SetActive(activePanel.Equals(ConnectPanel.name));
            RoomSelectPanel.SetActive(activePanel.Equals(RoomSelectPanel.name));
        }
    }
}