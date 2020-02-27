using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewHouseScript : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject TransparentHouse;
    public GameObject PlacedHouse;
    private bool housePlacing;
    void Start() {
        housePlacing = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(/******left mouse********/)) {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo)) {

            }
        }
    }
}
