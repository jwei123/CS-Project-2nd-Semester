using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CutTrees : MonoBehaviour
{
    public float woodAmount = 0; //Fix later with connection to resource bar. Right now we are assuming one tree = one piece of wood
    public Material treeGreen, treeHighlight;
    public int numPeopleAssignedToChopTrees = 5; //this is up here because it might get changed from other scripts. I might want to set it to grab some number in the update void.

    double timer = 0f;
    //how many to chop each frame, how many we've chopped this frame, and whether we should chop trees at all
    float amountToChop;
    float treesChopped;
    bool timeToChopTrees;

    void Update()
    {
        //each frame, get a new list of trees to chop down
        GameObject[] treesToChop = GameObject.FindGameObjectsWithTag("MarkedForChopping");

        timeToChopTrees = timer >= 1; //if it's been more than a second

        //only chop trees if it's time to do so
        if (timeToChopTrees) {

            treesChopped = 0;
            amountToChop = AmtCompletedPerUnitTime(numPeopleAssignedToChopTrees, 5, 1);
            treesToChop = GameObject.FindGameObjectsWithTag("MarkedForChopping");

            //if we are chopping trees, just go through the trees in order
            foreach (GameObject i in treesToChop)
            {
                //only cut the right amount of trees, and you can't cut down nonexistant trees
                if (treesChopped <= amountToChop && treesToChop.Length > 0)
                {
                    Destroy(i);
                    woodAmount++;
                    treesChopped++;
                }
                else { break; }

            }
        }

        timer += Time.deltaTime;

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

    //Generally, timeInterval will be in seconds. But whatever I don't really care.
    //This function calculates how much of some task is completed in some time interval. This is more useful than total time, because the number of people working may fluctate.
    public float AmtCompletedPerUnitTime(int numPeopleAssignedToTask, float difficulty, float timeInterval)
    {
        return numPeopleAssignedToTask / difficulty * timeInterval;
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

    

    

    
    
    
    
}
