using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float totalTime;
    void Start()
       {
        totalTime = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        transform.position = new Vector3(0, 0, Mathf.Sin(totalTime));
    }
}
