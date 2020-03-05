using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewHouseScript : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject TransparentHouse;
    public GameObject PlacedHouse;
    public Texture GrayscaleHouse;
    public Texture RedHouse;
    private bool housePlacing;
    void Start() {
        housePlacing = false;
    }
    void Update() {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hitInfo)) {
                if (hitInfo.collider.gameObject.CompareTag("Preview House")) {
                    housePlacing = !housePlacing;
                }
                else if (hitInfo.collider.gameObject.CompareTag("Ground")) {
                    if (housePlacing) {
                        GameObject newHouse = Instantiate(PlacedHouse);
                        newHouse.transform.position = hitInfo.point;
                        housePlacing = false;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(1)) {
            housePlacing = false;
        }
        if (Physics.Raycast(ray, out hitInfo, 1 << 9)) {
            if (hitInfo.collider.gameObject.CompareTag("Ground")) {
                if (housePlacing) {
                    TransparentHouse.transform.position = hitInfo.point;
                }
            }
        }
        TransparentHouse.SetActive(housePlacing);
    }
}
