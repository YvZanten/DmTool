using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    //imports
    public float SizeMin;
    public float SizeMax;
    
    //local
    private Camera cam;

    // Use this for initialization
    void Start ()
    {
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.unityLogger.Log(Input.mouseScrollDelta.y);
        float CamSize = cam.orthographicSize - Input.mouseScrollDelta.y;
        cam.orthographicSize = Mathf.Max(SizeMin, Mathf.Min(SizeMax, CamSize));
    }
}
