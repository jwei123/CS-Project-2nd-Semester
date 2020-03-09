using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewHouseScript : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject TransparentHouse;
    public GameObject PlacedHouse;
    public LayerMask Layer9Only;
    private bool housePlacing;
    void Start() {
        housePlacing = false;
    }
    void Update() {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0)) {
            cout("b");
            if (Physics.Raycast(ray, out hitInfo)) {
                cout("c");
                if (hitInfo.collider.gameObject.CompareTag("Preview House")) {
                    housePlacing = !housePlacing;
                    cout("d");
                }
                else {
                    if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, Layer9Only)) {
                        if (housePlacing) {
                            cout("f");
                            GameObject newHouse = Instantiate(PlacedHouse);
                            newHouse.transform.position = hitInfo.point;
                            housePlacing = false;
                        }
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(1)) {
            housePlacing = false;
        }
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, Layer9Only)) {
            if (housePlacing) {
                TransparentHouse.transform.position = hitInfo.point;
            }
        }
        TransparentHouse.SetActive(housePlacing);
    }
    private void cout(string input) {
        Debug.Log(input);
    }
}
