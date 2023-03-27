using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

using Hashtable = ExitGames.Client.Photon.Hashtable;

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

    public void SetAvatar1()
    {
        var hash = PhotonNetwork.LocalPlayer.CustomProperties;
        hash.Add("Avatar", "Avatar1");
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public void SetAvatar2()
    {
        var hash = PhotonNetwork.LocalPlayer.CustomProperties;
        hash.Add("Avatar", "Avatar2");
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}
