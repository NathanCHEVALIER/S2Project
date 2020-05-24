using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiToMenu : MonoBehaviour
{
    public void ExitMenu()
    {
        NetworkManager NetManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        NetManager.BackToMenu();
    }
}
