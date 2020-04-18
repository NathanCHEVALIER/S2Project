using System.Collections;
using System.Collections.Generic;
using Photon;
using TMPro.Examples;
using UnityEngine;

public class NetworkPlayer : Photon.PunBehaviour
{
    public Camera localCam;
    private Camera waitCam;

    private bool Status = false;
    private bool IsRunning = false;
    
    void Start()
    {
        UnityEngine.MonoBehaviour[] scripts = GetComponents<UnityEngine.MonoBehaviour>();
        if (!photonView.isMine)
        {
            localCam.enabled = this.Status;
            
            for (int i = 0; i < scripts.Length; i++)
            {
                if (scripts[i] is PlayerMvmt) scripts[i].enabled = false;
                else if (scripts[i] is AnimatorControler) scripts[i].enabled = false;
                else if (!IsRunning && scripts[i] is PlayerMvmt) scripts[i].enabled = false;
            }
        }
        else
        {
            for (int i = 0; i < scripts.Length; i++)
            {
                if (!IsRunning && scripts[i] is PlayerMvmt) scripts[i].enabled = false;
            }
        }
    }

    void Update()
    {
        localCam.enabled = this.Status;
    }

    public void setStatus(bool status, int id)
    {
        if (!this.Status && status)
        {
            this.Status = status;
            setCameraOn(id);
        }
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

    public void enableRunning()
    {
        IsRunning = true;
        UnityEngine.MonoBehaviour[] scripts = GetComponents<UnityEngine.MonoBehaviour>();
        
        for (int i = 0; i < scripts.Length; i++)
        {
            if (IsRunning && scripts[i] is PlayerMvmt) scripts[i].enabled = true;
        }
    }
}