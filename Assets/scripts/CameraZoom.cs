using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    //imports
    public float SizeMin;
    public float SizeMax;

    public GameObject GridManager;
    
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
        float ScrollDelta = Input.mouseScrollDelta.y;
        if(Input.GetKey(KeyCode.LeftControl) && ScrollDelta != 0)
        {
            float CamSize = cam.orthographicSize - ScrollDelta;
            cam.orthographicSize = Mathf.Max(SizeMin, Mathf.Min(SizeMax, CamSize));

            if (GridManager != null)
                GridManager.GetComponent<DrawLines>().RedrawGrid();
        }
    }
}
