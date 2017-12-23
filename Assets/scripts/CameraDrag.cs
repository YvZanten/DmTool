using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    //imports
    public float CamSpeed;

    //local
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
        //if M1 down
		if(Input.GetMouseButtonDown(0))
        {
            v3_MouseStart = Input.mousePosition;        //save mouse position
            v3_CameraStart = cam.transform.position;    //save cam position
            CamDrag = true;                             //start dragging
        }

        //if M1 up
        if (Input.GetMouseButtonUp(0))
        {
            CamDrag = false;    //stop dragging
        }

        //if dragging
        if(CamDrag)
        {
            Vector3 v3_MouseDirection = cam.ScreenToViewportPoint(Input.mousePosition - v3_MouseStart);
            Debug.unityLogger.Log("", "v3sm: " + v3_MouseStart + "\tv3mc: " + v3_MouseDirection);
            v3_MouseDirection *= -CamSpeed;

            //transform.Translate(v3_MouseDirection, Space.World);
            //cam.transform.position = (v3_CameraStart + v3_MouseDirection);   //move camera
        }
    }
}
