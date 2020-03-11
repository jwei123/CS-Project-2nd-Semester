using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChopClickUI : MonoBehaviour
{
    /*Call this script when we are in "Tree Chopping" mode.*/
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        //create highlight
    }

    // Update is called once per frame
    void Update()
    {
        //when we are in tree chopping mode, move the highlight with the mouse.
        //thing that can send ray from camera through mouse position
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //if it hit something, set the destination to the ray hit area
        if (Physics.Raycast(ray, out hit))
        {
            transform.GetComponent<CutTrees>().highlightTrees(hit.point, 20);
            if(Input.GetMouseButton(0))
            {
                transform.GetComponent<CutTrees>().markTreeToChop(hit.point, 20);
            }
        }
        //when mouse is clicked, "chop" trees using CutTrees script
        //hide the highlight otherwise
    }
}
