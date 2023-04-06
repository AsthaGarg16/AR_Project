using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.XR.ARFoundation;

public class SpawnGarden : MonoBehaviour
{
    public GameObject gardenPrefab;
    public ARSessionOrigin sessionCamera;
    public GameObject playerPrefab;

    public float[,] positions = new float[,]{ { 0, 0, 2 }, {4.4f,0,2 },{0,0,5.4f }, { 4.4f, 0, 5.4f} };
    public float[,] cameraPositions = new float[,] { { 0, 2, 0 }, { 4.4f, 2, 0 }, { 0, 2, 4.4f }, { 4.4f, 2, 4.4f } };
    public float[,] playerPositions = new float[,] { { 0, 0, 0 }, { 4.4f, 0, 0 }, { 0, 0, 4.4f }, { 4.4f, 0, 4.4f } };

    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {

        int gardenIndex = (int)PhotonNetwork.CurrentRoom.CustomProperties["GardenIndex"];
        PlayerPrefs.SetInt("PlayerIndex",gardenIndex);
        Vector3 position = new Vector3(positions[gardenIndex,0], positions[gardenIndex,1], positions[gardenIndex,2]);
        Vector3 cameraPosition = new Vector3(cameraPositions[gardenIndex, 0], cameraPositions[gardenIndex, 1], cameraPositions[gardenIndex, 2]);
        Vector3 playerPosition = new Vector3(playerPositions[gardenIndex, 0], playerPositions[gardenIndex, 1], playerPositions[gardenIndex, 2]);
        
        PhotonNetwork.Instantiate(gardenPrefab.name, position, Quaternion.identity);
        Debug.Log("Instantiating garden at " + position);
        
        sessionCamera.transform.position = cameraPosition;
       
        playerObject = PhotonNetwork.Instantiate(playerPrefab.name, playerPosition, Quaternion.identity);
        playerObject.layer = LayerMask.NameToLayer("RemotePlayer");
        // Set the culling mask of the local player's camera to not render the layer assigned to the player object
        Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("RemotePlayer"));
        Debug.Log("Instantiating player at " + playerPosition);
        
        ExitGames.Client.Photon.Hashtable roomProps = PhotonNetwork.CurrentRoom.CustomProperties;
        roomProps["GardenIndex"] = gardenIndex + 1;
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomProps);
    }

    // Update is called once per frame
    void Update()
    {

        // Update the position and rotation of the player object based on the ARSessionOrigin's transform
        playerObject.transform.position = sessionCamera.transform.position;
        playerObject.transform.rotation = sessionCamera.transform.rotation;
    }
}
