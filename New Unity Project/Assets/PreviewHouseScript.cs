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
    private int houseRotation;
    void Start() {
        housePlacing = false;
        houseRotation = 0;
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
                            newHouse.transform.rotation = TransparentHouse.transform.rotation;
                            housePlacing = false;
                            ChangeHouseRotation(-houseRotation);
                        }
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(1)) {
            housePlacing = false;
        }
        if (Input.GetButtonDown("Fire2") && housePlacing) {
            /*houseRotation += 30;
            TransparentHouse.transform.rotation = Quaternion.Euler(new Vector3(0, 30, 0)) * TransparentHouse.transform.rotation;*/
            ChangeHouseRotation(30);
        }
        if (Input.GetButtonDown("Fire3") && housePlacing) {
            /*houseRotation -= 30;
            TransparentHouse.transform.rotation = Quaternion.Euler(new Vector3(0, -30, 0)) * TransparentHouse.transform.rotation;*/
            ChangeHouseRotation(-30);
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
    private void ChangeHouseRotation(int change) {
        houseRotation += change;
        TransparentHouse.transform.rotation = Quaternion.Euler(new Vector3(0, change, 0)) * TransparentHouse.transform.rotation;
    }
}
