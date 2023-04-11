using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAnimation : MonoBehaviour
{
    public GameObject axe; 
    public float[,] positions = new float[,] { { 0, 1, 1 }, { 5, 1, 1 }, { 0, 1, 6 }, { 5, 1, 6 } };
    /*public float tiltAngle = 90.0f;
    public float rotationSpeed = 10f;
    public float swingRate;*/

    // Start is called before the first frame update
    void Start()
    {

        GameObject axeNode = null;
        int index = PlayerPrefs.GetInt("PlayerIndex");
        Vector3 position = new Vector3((float)(positions[index, 0]), positions[index, 1], positions[index, 2]);
        axeNode = Instantiate(axe);
        axeNode.transform.parent = transform;
        axeNode.transform.localPosition = position; 
        axeNode.transform.localRotation = Quaternion.identity;

        axe.gameObject.SetActive(false);

        /*startTime = Time.time;
        endTime = startTime + growthDuration;*/
        transform.Rotate(90f, 0, 0);

    }
    public void controller()
    {
        axe.gameObject.SetActive(true);
        if (Time.time == 5.0f)
        {
            axe.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        /*float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, axe,  Time.deltaTime * smooth);*/
        /*float swingSpeed = swingRate * Time.deltaTime;
        axeNode.transform.Rotate(0f, rotationSpeed * swingSpeed, 0f);
        if (Time.time == 3.0f) { return; }*/
        /*axe.transform.Rotate(0f, 45f, 0f);*/
    }
}
