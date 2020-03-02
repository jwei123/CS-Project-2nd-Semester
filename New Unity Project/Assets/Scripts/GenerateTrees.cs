using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTrees : MonoBehaviour
{
    public GameObject treePrefab;

    public float terrainWidth = 500;
    public float treeSpacing = 20;

    // Start is called before the first frame update
    void Start()
    {
        for(float x = 0; x < terrainWidth; x += treeSpacing)
        {
            for(float z = 0; z < terrainWidth; z += treeSpacing)
            {
                GameObject newTree = Instantiate(treePrefab);
                newTree.transform.SetParent(transform);
                newTree.transform.position = new Vector3(transform.position.x + x, 0, transform.position.z + z);
            }
            
        }
    }
}
