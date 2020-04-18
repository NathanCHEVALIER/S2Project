using System.Collections;
using System.Collections.Generic;
using Photon;
using TMPro.Examples;
using UnityEngine;

public class NetworkPlayer : Photon.PunBehaviour, IPunObservable
{
    public Camera localCam;
    private Camera waitCam;

    private bool Status = false;
    
    void Start()
    {
        if (!photonView.isMine)
        {
            localCam.enabled = this.Status;

            UnityEngine.MonoBehaviour[] scripts = GetComponents<UnityEngine.MonoBehaviour>();

            for (int i = 0; i < scripts.Length; i++)
            {
                if (scripts[i] is NetworkPlayer) continue;
                else if (scripts[i] is PhotonView) continue;

                scripts[i].enabled = false;
            }
        }
        
        PhotonView pv = GetComponent<PhotonView>();
        pv.ObservedComponents.Add(this);
    }

    void Update()
    {
        localCam.enabled = this.Status;
    }

    public bool setStatus(bool status = true)
    {
        this.Status = status;
        setCameraOn();
        return status;
    }

    public void setCameraOn()
    {
        if (this.Status)
        {
            localCam.enabled = this.Status;
            transform.position = new Vector3((float)-24.5, 4, (float)-0.5);
            transform.Rotate(0, -90, 0);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(this.Status);
        }
        else
        {
            this.Status = (bool)stream.ReceiveNext();
            Debug.Log(this.Status);
            setCameraOn();
        }
    }
    
}