using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour
{
    public GameObject localCam;
    
    void Start()
    {
        if (!photonView.isMine)
        {
            localCam.SetActive(false);

            MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

            for (int i = 0; i < scripts.Length; i++)
            {
                if (scripts[i] is NetworkPlayer) continue;
                else if (scripts[i] is PhotonView) continue;

                scripts[i].enabled = false;
            }
        }
    }
}