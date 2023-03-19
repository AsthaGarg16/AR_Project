using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkConnector : MonoBehaviourPunCallbacks
{
    // Add a reference to our player prefab
    public GameObject playerPrefab;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    #region Pun Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to photon!");
        //PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        // Failed to connect to random, probably because none exist
        Debug.Log(message);

        // Create a new room
        PhotonNetwork.CreateRoom("My First Room");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"{PhotonNetwork.CurrentRoom.Name} joined!");
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 3.0f, 0), Quaternion.identity);
    }


    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarning($"Failed to connect: {cause}");
    }

    #endregion
}