using TMPro.Examples;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour
{
    public Camera localCam;

    private bool Status = false;
    
    void Start()
    {
        if (!photonView.isMine)
        {
            localCam.enabled = this.Status;

            MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length; i++)
            {
                if (scripts[i] is NetworkPlayer) continue;
                else if (scripts[i] is PhotonView) continue;

                scripts[i].enabled = false;
            }
        }
    }

    void Update()
    {
        localCam.enabled = this.Status;
    }

    public bool setStatus(bool status = true)
    {
        this.Status = status;
        localCam.enabled = this.Status;
        transform.Rotate(0, -90, 0);
        return status;
    }
    
}