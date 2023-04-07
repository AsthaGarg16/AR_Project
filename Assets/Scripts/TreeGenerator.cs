using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*TO_DO
 *          rootNode2 = Instantiate(treePrefab2);
            rootNode2.transform.parent = transform;
            rootNode2.transform.localPosition = Vector3.zero;
            rootNode2.transform.localRotation = Quaternion.identity;
 */
public class TreeGenerator : MonoBehaviour
{
    /*public GameObject flower;
    public GameObject flower1;*/

    public GameObject treePrefab;
    public GameObject treePrefab2;
    public GameObject treePrefab3;
    public GameObject treePrefab4;
    public GameObject treePrefab5;
    public GameObject treePrefab6;
    public GameObject treePrefab7;
    public GameObject treePrefab8;
    public GameObject treePrefab9;
    public Texture treeTexture;
    public float growthRate;
    public float growthDuration;

    //public float curTime;
    public int select_tree;
    public bool tree1;
    public bool tree2 = false;
    public bool tree3 = false;

    private float startTime;
    private float endTime;
    private bool isGrowing;
    /*public float[,] positions = new float[,] { { 0, 0, 2 }, { 4.4f, 0, 2 }, { 0, 0, 5.4f }, { 4.4f, 0, 5.4f } };*/
    public float[,] positions = new float[,] { { 0, 0, 2 }, { 5, 0, 2 }, { 0, 0, 7 }, { 5, 0, 7 } };

    public int count = 0;

    public void Start()
    {
            
        // GenerateTree2();
    }

    public void GenerateTree2()    
    {
        // Define tree structure using a class or struct
        /*GameObject flowerNode = null;
        GameObject flowerNode2 = null;*/
        GameObject rootNode = null;
        select_tree = PlayerPrefs.GetInt("tree");
        GameObject rootNode2 = null;
        GameObject rootNode3 = null;
        //Debug.Log(select_tree0);
        tree1 = true;
        Debug.Log(tree2);
        int index = PlayerPrefs.GetInt("PlayerIndex");
        Vector3 position = new Vector3(positions[index, 0] + count * 5, positions[index, 1], positions[index, 2]);
        Debug.Log(index);
        Debug.Log(position);


        // Create root node at base of tree
        if (tree1 & !tree2 & !tree3)
        {
            /*flowerNode = Instantiate(flower);
            flowerNode.transform.parent = transform;
            flowerNode.transform.localPosition = new Vector3(positions[index, 0] + count * 5 + 2, positions[index, 1], positions[index, 2]);
            flowerNode.transform.localRotation = Quaternion.identity;

            flowerNode2 = Instantiate(flower);
            flowerNode2.transform.parent = transform;
            flowerNode2.transform.localPosition = new Vector3(positions[index, 0] + count * 5 - 2, positions[index, 1], positions[index, 2]);
            flowerNode2.transform.localRotation = Quaternion.identity;*/

            if (select_tree == 0)
            {
                Debug.Log(position);
                rootNode = Instantiate(treePrefab);
                rootNode.transform.parent = transform;
                rootNode.transform.localPosition = position;
                rootNode.transform.localRotation = Quaternion.identity;
            }
            /*rootNode = Instantiate(treePrefab);
            rootNode.transform.parent = transform;
            rootNode.transform.localPosition = Vector3.zero;
            rootNode.transform.localRotation = Quaternion.identity;*/

            if (select_tree == 1)
            {
                rootNode = Instantiate(treePrefab4);
                rootNode.transform.parent = transform;
                rootNode.transform.localPosition = position;
                rootNode.transform.localRotation = Quaternion.identity;
            }
            //add another select_tree == 2
            if (select_tree == 2)
            {
                rootNode = Instantiate(treePrefab7);
                rootNode.transform.parent = transform;
                rootNode.transform.localPosition = position;
                rootNode.transform.localRotation = Quaternion.identity;
            }
        }

        if (tree1 & tree2 & !tree3)
        {   
            Object.Destroy(transform.GetChild(count).gameObject);
            if (select_tree == 0)
            {
                //Destroy(rootNode);
                

                rootNode2 = Instantiate(treePrefab2);
                rootNode2.transform.parent = transform;
                rootNode2.transform.localPosition = position;
                rootNode2.transform.localRotation = Quaternion.identity;


            }

            if (select_tree == 1)
            {
                //Object.Destroy(transform.GetChild(0));
                Object.Destroy(transform.GetChild(count).gameObject);

                rootNode2 = Instantiate(treePrefab5);
                rootNode2.transform.parent = transform;
                rootNode2.transform.localPosition = position;
                rootNode2.transform.localRotation = Quaternion.identity;
            }
            //add another select_tree == 2
            if (select_tree == 2)
            {
                rootNode2 = Instantiate(treePrefab8);
                rootNode2.transform.parent = transform;
                rootNode2.transform.localPosition = position;
                rootNode2.transform.localRotation = Quaternion.identity;
            }
        }

        if (tree1 & tree2 & tree3)
        {
            Object.Destroy(transform.GetChild(count).gameObject);
            Debug.Log("Hm");
            if (select_tree == 0)
            {
                Debug.Log("Hi");

                rootNode3 = Instantiate(treePrefab3);
                rootNode3.transform.parent = transform;
                rootNode3.transform.localPosition = position;
                rootNode3.transform.localRotation = Quaternion.identity;
            }
            /*rootNode = Instantiate(treePrefab);
            rootNode.transform.parent = transform;
            rootNode.transform.localPosition = Vector3.zero;
            rootNode.transform.localRotation = Quaternion.identity;*/

            if (select_tree == 1)
            {
                rootNode3 = Instantiate(treePrefab6);
                rootNode3.transform.parent = transform;
                rootNode3.transform.localPosition = position;
                rootNode3.transform.localRotation = Quaternion.identity;
            }
            //add another select_tree == 2
            if (select_tree == 2)
            {
                rootNode3 = Instantiate(treePrefab9);
                rootNode3.transform.parent = transform;
                rootNode3.transform.localPosition = position;
                rootNode3.transform.localRotation = Quaternion.identity;
            }
        }


        // Start growing tree
        startTime = Time.time;
        endTime = startTime + growthDuration;
        isGrowing = true;

    }

    public void Update()
    {
    // Check if tree is currently growing
        if (isGrowing)
        {
            // Calculate how much time has passed since growth started
            float elapsed = Time.time - startTime;

            // Calculate how much the tree should have grown by now
            float growth = Time.time / growthDuration;
            //Debug.Log(elapsed);


            // Stop growing the tree if it has reached its final size
            /*if (growth >= 1.0f)
            {
                isGrowing = false;
                PlayerPrefs.SetInt("tree", 0);
                count += 1;
                tree2 = false;
                tree3 = false;
                return;
            }*/

            /*if (tree1 & tree2) // put & tree 3
            {
                isGrowing = false;
                return;
            }*/

            if (elapsed >= growthDuration/3)
            {
                if (tree3 == true)
                {
                    isGrowing = false;
                    
                    PlayerPrefs.SetInt("tree", 0);
                    count += 1;
                    tree2 = false;
                    tree3 = false;
                    return;
                }

                if (tree2 == true)
                {
                    isGrowing = false;
                    tree3 = true;
                    GenerateTree2();

                }

                if (tree1 == true && tree2 != true)
                {
                    //DestroyImmediate(treePrefab,true);
                    isGrowing = false;
                    tree2 = true;
                    GenerateTree2();

                }


            }


            // Grow the tree by scaling it up
            float scaleFactor = growthRate * Time.deltaTime;
            transform.GetChild(count).localScale += Vector3.one * scaleFactor;
        }


    }
}

    









