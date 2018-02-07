using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {

    public int currentCam = 0;

    public Vector3[] cameraPositions = new[] { new Vector3(10.3f, 4.15f, 0f), new Vector3(0.78f, 1.41f, 0f) };

    private Camera mainCam;

	// Use this for initialization
	void Start () {
        mainCam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCam++;

            if(currentCam >= cameraPositions.Length)
            {
                currentCam = 0;
            }

            mainCam.transform.localPosition = cameraPositions[currentCam];
        }
    }
}
