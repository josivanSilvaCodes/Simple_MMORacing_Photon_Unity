using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class MenuMMOR : MonoBehaviour
{
    // Scene MENU
    public Button buttonConnectNickname;
    public InputField InputConnectNickname;
    public Button buttonPrivateRoom;
    public InputField inputPrivateRoomName;
    public Button buttonSelectRoom;
    public InputField selectRoomName;
    public Text status;

    public void buttonConnectClicked()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            StartCoroutine(Connecting(3));
        }
    }

    public void buttonPrivateRoomClicked()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.CreateRoom(inputPrivateRoomName.text);
            Debug.Log("Created Room with Name: " + PhotonNetwork.CurrentRoom);
            StartCoroutine(ChangeLevel(2, "Selection"));
        }
    }

    public void buttonSelectRoomClicked()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRoom(selectRoomName.text);
            Debug.Log("Join Room by Name: " + PhotonNetwork.CurrentRoom);
            StartCoroutine(ChangeLevel(2, "Selection"));
        }
    }

    IEnumerator Connecting(int time)
    {
        yield return new WaitForSeconds(time);
        status.text = "Connected as " + InputConnectNickname.text;
    }

    IEnumerator ChangeLevel(int time, string levelName)
    {
        yield return new WaitForSeconds(time);
        PhotonNetwork.LoadLevel(levelName);
    }    
}
