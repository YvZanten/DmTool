using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
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
        if(!Input.GetKey(KeyCode.LeftControl) && ScrollDelta != 0)
        {
            bool shift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            if(!shift)
                cam.transform.position += new Vector3(0, ScrollDelta * 1.5f);
            else
                cam.transform.position += new Vector3(ScrollDelta * -1.5f, 0);
        }
	}
}
