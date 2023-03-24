using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class ProfileManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveProfile()
    {
        SetUsername();
    }

    public void SetUsername()
    {
        PhotonNetwork.NickName = usernameInput.text;
    }
}
