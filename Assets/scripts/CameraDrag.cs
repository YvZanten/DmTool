using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    //imports
    public float CamSpeed;

    //local
    private Camera cam;

    private Vector3 MousePos;
    private Vector3 CameraPos;
    private bool CamDrag;

	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();

        MousePos = new Vector3();
        CamDrag = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if M1 down
		if(Input.GetMouseButtonDown(0))
        {
            MousePos = cam.ScreenToWorldPoint(Input.mousePosition);     //save mouse position
            CameraPos = cam.transform.position; //save cam position
            CamDrag = true;                     //start dragging
        }

        //if M1 up
        if (Input.GetMouseButtonUp(0))
        {
            CamDrag = false;    //stop dragging
        }

        //if dragging
        if(CamDrag)
        {
            Vector3 MouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition) - MousePos * -CamSpeed;
            cam.transform.position = (CameraPos + MouseWorldPos);    //move camera
        }
    }
}
