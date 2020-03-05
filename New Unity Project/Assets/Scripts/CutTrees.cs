using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTrees : MonoBehaviour
{
    public float woodAmount; //Fix later with connection to resource bar. Right now we are assuming one tree = one piece of wood
    public bool cutWoodNow = false;

    private void Update()
    {
        if(cutWoodNow)
        {
            cutDownTrees(new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500)), 40);
            cutWoodNow = false;
            Debug.Log("I tried to cut trees");
        }
       
    }

    void cutDownTrees(Vector3 location, float radius)
    {
        //go through each tree in this area. If it's close to the place of killing trees, destroy the tree.
        for(int i = transform.childCount - 1; i >= 0; i --)
        {
            //these should be global positions!
            if(Vector3.Distance(transform.GetChild(i).position, location) < radius)
            {
                Destroy(transform.GetChild(i).gameObject);
                woodAmount++;
            }
            
        }
    }
    
    
    
}
