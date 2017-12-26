using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    //imports
    public float CamSpeed;

    //local
    public bool ControlActive = false;

    private Camera cam;

    private Vector3 v3_MouseStart;
    private Vector3 v3_CameraStart;
    private bool CamDrag;

	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();

        v3_MouseStart = new Vector3();
        CamDrag = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!ControlActive)
            return;

        //if M1 down
		if(Input.GetMouseButtonDown(0))
        {
            v3_MouseStart = cam.ScreenToWorldPoint(Input.mousePosition);    //save mouse position
            v3_CameraStart = cam.transform.position;                        //save cam position
            CamDrag = true;                                                 //start dragging
        }

        //if M1 up
        if (Input.GetMouseButtonUp(0))
        {
            CamDrag = false;    //stop dragging
        }

        //if dragging
        if(CamDrag)
        {
            Vector3 v3_MouseCurrent = cam.ScreenToWorldPoint(Input.mousePosition);      //get current mouse pos in world
            Vector3 v3_MouseDiff = v3_MouseCurrent - v3_MouseStart;                     //get difference between start and current pos
            
            cam.transform.position = (v3_CameraStart - v3_MouseDiff);       //move camera by difference
            v3_CameraStart = cam.transform.position;                        //save cam position
            v3_MouseStart = cam.ScreenToWorldPoint(Input.mousePosition);    //save mouse position
        }
    }
}
