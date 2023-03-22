using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string sceneToLoad = "Room Scene";

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
