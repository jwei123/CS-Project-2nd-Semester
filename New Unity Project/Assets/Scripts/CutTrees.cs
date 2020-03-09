using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTrees : MonoBehaviour
{
    public float woodAmount; //Fix later with connection to resource bar. Right now we are assuming one tree = one piece of wood
    public bool cutWoodNow = false;
    public Material mat1;

    private void Update()
    {
        if(cutWoodNow)
        {
            cutDownTrees(new Vector3(Random.Range(0, 500), 0, Random.Range(0, 500)), 40);
            cutWoodNow = false;
        }
       
    }
    
    //find trees within some radius. Use them for whatever.
    public List<GameObject> findTreesInRadius(Vector3 location, float radius)
    {
        List<GameObject> myTrees = new List<GameObject>();
        //go through each tree in this area. If it's close to the place of killing trees, destroy the tree.
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            //these should be global positions!
            if (Vector3.Distance(transform.GetChild(i).position, location) < radius)
            {
                myTrees.Add(transform.GetChild(i).gameObject);
            }

        }

        return myTrees;
    }

    //destroy the trees
    public void cutDownTrees(Vector3 location, float radius)
    {
        List<GameObject> treesToChop = findTreesInRadius(location, radius);
        for(int i = treesToChop.Count - 1; i >= 0; i--)
        {
            Destroy(treesToChop[i]);
        }
    }

    public void highlightTrees(Vector3 location, float radius)
    {
        List<GameObject> treesToHighlight = findTreesInRadius(location, radius);
        for(int i = transform.childCount - 1; i >= 0; i --)
        {
            //make it green
        }

        for(int i = 0; i < treesToHighlight.Count; i ++)
        {

        }
    }
    
    
    
}
