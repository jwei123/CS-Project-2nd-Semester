using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTrees : MonoBehaviour
{
    public float woodAmount = 0; //Fix later with connection to resource bar. Right now we are assuming one tree = one piece of wood
    public Material treeGreen, treeHighlight;
    public int numPeopleAssignedToChopTrees; //this is up here because it might get changed from other scripts. I might want to set it to grab some number in the update void.

    
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

    //Marks all of the trees within some radius for chopping at a later time via gameObject tag
    public void markTreeToChop(Vector3 location, float radius)
    {
        List<GameObject> treesToChop = findTreesInRadius(location, radius);
        for (int i = treesToChop.Count - 1; i >= 0; i--)
        {
            treesToChop[i].gameObject.tag = "MarkedForChopping";
            treesToChop[i].GetComponent<MeshRenderer>().material = treeHighlight;
        }
    }

    /************************************Probably don't need this*******************************************************/
    //To make more efficient, store the last few trees that were highlighted and just revert those colors
    public void highlightTrees(Vector3 location, float radius)
    {
        List<GameObject> treesToHighlight = findTreesInRadius(location, radius);
        //this goes through all of the trees and makes them green
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            //make it green
            if(transform.GetChild(i).gameObject.tag != "MarkedForChopping")
            {
                transform.GetChild(i).GetComponent<MeshRenderer>().material = treeGreen;
            }          
        }

        for (int i = 0; i < treesToHighlight.Count; i++)
        {
            treesToHighlight[i].GetComponent<MeshRenderer>().material = treeHighlight;
        }
    }

    //destroy the trees in some radius
    //What should this do? Cutting one tree = destroy + add to woodAmount
    //Cut down all trees in some list? That would be cutting down all marked trees
    /*Eventually, some trees should get cut down as a function of how many tree cutters there are. So should this be that function? 
     * I want a more general function for tasks...Like, how much of this should be done per minute, and it should change when people are reassigned */
     //Okay, this function cuts down some of the trees...
    public void cutDownTrees()
    {
        GameObject[] treesToChop = GameObject.FindGameObjectsWithTag("MarkedForChopping");

        float amountToChop = AmtCompletedPerUnitTime(numPeopleAssignedToChopTrees, 5, 1);
        float treesChopped = 0;
        //While there are still trees to chop, chop some number of trees every second...
        while(treesToChop.Length > 0)
        {
            //if (timeToChopTrees)
            treesToChop = GameObject.FindGameObjectsWithTag("MarkedForChopping");
            foreach (GameObject i in treesToChop)
            {
                if (treesChopped <= amountToChop)
                {
                    Destroy(i);
                    woodAmount++;
                    treesChopped++;
                }
                else { break; }

            }
        }
        
    }

    //Generally, timeInterval will be in seconds. But whatever I don't really care.
    //This function calculates how much of some task is completed in some time interval. This is more useful than total time, because the number of people working may fluctate.
    public float AmtCompletedPerUnitTime(int numPeopleAssignedToTask, float difficulty, float timeInterval)
    {
        return numPeopleAssignedToTask/difficulty*timeInterval;
    }

    
    
    
    
}
