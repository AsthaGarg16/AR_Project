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

    public GameObject treePrefab;
    public GameObject treePrefab2;
    public GameObject treePrefab3;
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

    public void Start()
    {
        // GenerateTree2();
    }

    public void GenerateTree2()
    {
        // Define tree structure using a class or struct
        GameObject rootNode = null;
        select_tree = PlayerPrefs.GetInt("tree");
        GameObject rootNode2 = null;
        GameObject rootNode3 = null;
        //Debug.Log(select_tree0);
        tree1 = true;
        Debug.Log(tree2);

        // Create root node at base of tree
        if (tree1 & !tree2 & !tree3)
        {
            if (select_tree == 0)
            {
                rootNode = Instantiate(treePrefab);
                rootNode.transform.parent = transform;
                rootNode.transform.localPosition = Vector3.zero;
                rootNode.transform.localRotation = Quaternion.identity;
            }
            /*rootNode = Instantiate(treePrefab);
            rootNode.transform.parent = transform;
            rootNode.transform.localPosition = Vector3.zero;
            rootNode.transform.localRotation = Quaternion.identity;*/

            if (select_tree == 1)
            {
                rootNode = Instantiate(treePrefab);
                rootNode.transform.parent = transform;
                rootNode.transform.localPosition = Vector3.zero;
                rootNode.transform.localRotation = Quaternion.identity;
            }
            //add another select_tree == 2
            if (select_tree == 2)
            {
                rootNode = Instantiate(treePrefab);
                rootNode.transform.parent = transform;
                rootNode.transform.localPosition = Vector3.zero;
                rootNode.transform.localRotation = Quaternion.identity;
            }
        }

        if (tree1 & tree2 & !tree3)
         {
                if (select_tree == 0)
                {
                //Destroy(rootNode);
                    Object.Destroy(transform.GetChild(0).gameObject);

                    rootNode2 = Instantiate(treePrefab2);
                    rootNode2.transform.parent = transform;
                    rootNode2.transform.localPosition = Vector3.zero;
                    rootNode2.transform.localRotation = Quaternion.identity;

                    
                }
                /*rootNode = Instantiate(treePrefab);
                rootNode.transform.parent = transform;
                rootNode.transform.localPosition = Vector3.zero;
                rootNode.transform.localRotation = Quaternion.identity;*/

                if (select_tree == 1)
                {
                //Object.Destroy(transform.GetChild(0));
                    Object.Destroy(transform.GetChild(0).gameObject);

                    rootNode2 = Instantiate(treePrefab2);
                    rootNode2.transform.parent = transform;
                    rootNode2.transform.localPosition = Vector3.zero;
                    rootNode2.transform.localRotation = Quaternion.identity;
                }
                //add another select_tree == 2
                if (select_tree == 2)
                {
                    rootNode2 = Instantiate(treePrefab2);
                    rootNode2.transform.parent = transform;
                    rootNode2.transform.localPosition = Vector3.zero;
                    rootNode2.transform.localRotation = Quaternion.identity;
                }
        }

        if (tree1 & tree2 & tree3)
        {
            if (select_tree == 0)
            {
                Object.Destroy(transform.GetChild(0).gameObject);
                rootNode3 = Instantiate(treePrefab3);
                rootNode3.transform.parent = transform;
                rootNode3.transform.localPosition = Vector3.zero;
                rootNode3.transform.localRotation = Quaternion.identity;
            }
            /*rootNode = Instantiate(treePrefab);
            rootNode.transform.parent = transform;
            rootNode.transform.localPosition = Vector3.zero;
            rootNode.transform.localRotation = Quaternion.identity;*/

            if (select_tree == 1)
            {
                rootNode3 = Instantiate(treePrefab2);
                rootNode3.transform.parent = transform;
                rootNode3.transform.localPosition = Vector3.zero;
                rootNode3.transform.localRotation = Quaternion.identity;
            }
            //add another select_tree == 2
            if (select_tree == 2)
            {
                rootNode3 = Instantiate(treePrefab2);
                rootNode3.transform.parent = transform;
                rootNode3.transform.localPosition = Vector3.zero;
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
            Debug.Log(elapsed);

            /*if (elapsed == 8.0 || elapsed = 16.0)
            {

            }*/

            // Stop growing the tree if it has reached its final size
            if (growth >= 1.0f)
            {
                isGrowing = false;
                return;
            }

            /*if (tree1 & tree2) // put & tree 3
            {
                isGrowing = false;
                return;
            }
*/
            if (elapsed >= 8.0)
            {
                if (tree2 == true)
                {
                    isGrowing = false;
                    tree3 = true;
                    GenerateTree2();

                }

                if(tree1 == true)
                {
                    //DestroyImmediate(treePrefab,true);
                    isGrowing = false;
                    tree2 = true;
                    GenerateTree2();

                }


            }


            // Grow the tree by scaling it up
            float scaleFactor = growthRate * Time.deltaTime;
            transform.localScale += Vector3.one * scaleFactor;
        }


    }
}

