using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections;

public class SelectionArenaCar : MonoBehaviour
{
    bool entrou = false;
    bool clicouOK = false;
    public string carPlayer = "";
    public string scene = "";

    public Button buttonArena1; 
    public Button buttonArena2;

    public Button buttonBlueCar;
    public Button buttonGreenCar;
    public Button buttonRedCar;
    public Button buttonYellowCar;

    public Button button_OK_Next;

    public Text TextClick_OK;

    public Sprite buttonArena1OFF;
    public Sprite buttonArena2OFF;

    public Sprite buttonBlueCarOFF;
    public Sprite buttonGreenCarOFF;
    public Sprite buttonRedCarOFF;
    public Sprite buttonYellowCarOFF;    

    public void buttonArena1Clicked(){  buttonArena1.image.overrideSprite = buttonArena1OFF; scene = "Arena_1"; }
    public void buttonArena2Clicked(){  buttonArena2.image.overrideSprite = buttonArena2OFF; scene = "Arena_2"; }

    public void buttonBlueCarClicked(){ buttonBlueCar.image.overrideSprite = buttonBlueCarOFF; carPlayer="BlueRaceCarCS";}
    public void buttonGreenCarClicked() { buttonGreenCar.image.overrideSprite = buttonGreenCarOFF; carPlayer="GreenRaceCarCS";}
    public void buttonRedCarClicked() { buttonRedCar.image.overrideSprite = buttonRedCarOFF; carPlayer = "RedRaceCarCS"; }
    public void buttonYellowCarClicked() { buttonYellowCar.image.overrideSprite = buttonYellowCarOFF; carPlayer="YellowRaceCarCS"; }  

    public void button_OK_Next_Clicked() {
        
        Debug.Log("Scene: " + scene + " and " + "Car: " + carPlayer);

        TextClick_OK.text = "Wait for the other player...";
        clicouOK = true;
    }

    void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2 && entrou == false && clicouOK == true)
        {
            TextClick_OK.text = "Lets GO...";
            entrou = true;
            ChangeLevel();
        }
    }

    void ChangeLevel()
    {
        PhotonNetwork.LoadLevel(scene);
        System.Threading.Thread.Sleep(4000);

        byte group = 0;

        if (scene == "Arena_1")
        {
            if (carPlayer == "BlueRaceCarCS")
            { PhotonNetwork.Instantiate(carPlayer, new Vector3(-443f, 11f, -1122f), Quaternion.identity, group); }
            if (carPlayer == "GreenRaceCarCS")
            { PhotonNetwork.Instantiate(carPlayer, new Vector3(-33f, 11f, -465f), Quaternion.identity, group); }
            if (carPlayer == "RedRaceCarCS")
            { PhotonNetwork.Instantiate(carPlayer, new Vector3(-400f, 11f, -1122f), Quaternion.identity, group); }
            if (carPlayer == "YellowRaceCarCS")
            { PhotonNetwork.Instantiate(carPlayer, new Vector3(-1120f, 11f, -1546f), Quaternion.identity, group); }

        }

        if (scene == "Arena_2")
        {
            if (carPlayer == "BlueRaceCarCS")
            { PhotonNetwork.Instantiate(carPlayer, new Vector3(-443f, 11f, -1122f), Quaternion.identity, group); }
            if (carPlayer == "GreenRaceCarCS")
            { PhotonNetwork.Instantiate(carPlayer, new Vector3(-33f, 11f, -465f), Quaternion.identity, group); }
            if (carPlayer == "RedRaceCarCS")
            { PhotonNetwork.Instantiate(carPlayer, new Vector3(-480f, 11f, -1735f), Quaternion.identity, group); }
            if (carPlayer == "YellowRaceCarCS")
            { PhotonNetwork.Instantiate(carPlayer, new Vector3(-1120f, 11f, -1546f), Quaternion.identity, group); }

        }


    }

}
