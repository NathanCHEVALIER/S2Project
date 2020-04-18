using System.Collections;
using System.Collections.Generic;
using Photon;
using TMPro.Examples;
using UnityEngine;

public class NetworkPlayer : Photon.PunBehaviour//, IPunObservable
{
    public Camera localCam;
    private Camera waitCam;

    private bool Status = false;
    
    void Start()
    {
        /*if (!photonView.isMine)
        {
            localCam.enabled = this.Status;

            UnityEngine.MonoBehaviour[] scripts = GetComponents<UnityEngine.MonoBehaviour>();

            for (int i = 0; i < scripts.Length; i++)
            {
                if (scripts[i] is NetworkPlayer) continue;
                else if (scripts[i] is PhotonView) continue;
                else if (scripts[i] is AnimatorControler) continue;

                scripts[i].enabled = false;
            }
        }*/
    }

    void Update()
    {
        localCam.enabled = this.Status;
    }

    public bool setStatus(bool status, int id)
    {
        if (!this.Status && status)
        {
            this.Status = status;
            setCameraOn(id);
        }
        return status;
    }

    public void setCameraOn(int id)
    {
        if (this.Status)
        {
            localCam.enabled = this.Status;
            transform.position = new Vector3((float)-24.5 + (float)id, 4, (float)-0.5);
            transform.Rotate(0, -90, 0);
        }
    }

}