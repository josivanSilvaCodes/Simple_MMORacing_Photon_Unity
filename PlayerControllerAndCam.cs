
using UnityEngine;
using Photon.Pun;

public class PlayerControllerAndCam : MonoBehaviour
{
    public Camera cameraMMOR;
 
    //public GameObject bullet = null;
    //public float lifebar = 50;
    byte group = 0;

    private PhotonView photonview;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        transform.tag = "Player";

        cameraMMOR.transform.localPosition = new Vector3(-0.5f, 2.9f, -5.86f);
        cameraMMOR.transform.localRotation = Quaternion.identity;
        cameraMMOR.enabled = true;
    
        photonview = PhotonView.Get(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!photonview.IsMine)
        {
            cameraMMOR.enabled = false;
            return;
        }
        else
        {
            cameraMMOR.enabled = true;
        }


        Controll();
        CameraFPS();

        if (Input.GetMouseButtonDown(0))
        {
            //Fire();
        }

        /*if (lifebar <= 0)
        {
            PhotonNetwork.Destroy(this.gameObject);
        }
        */

    }

    public void Controll()
    {
       
    }

    public void CameraFPS()
    {
       
    }

 
    public void Fire()
    {
        //Debug.Log(this.transform.GetChild(1).GetChild(0).name);
        /*
        Vector3 pos = (this.transform.GetChild(0).GetChild(1).position - new Vector3(0, 0.05f, 0));
        Quaternion rot = this.transform.GetChild(0).GetChild(1).rotation;
        GameObject fire = PhotonNetwork.Instantiate(bullet.name, pos, rot, group);

        Destroy(fire, 4);
        */
    }
}
