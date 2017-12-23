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
            //get target location of mouse
            Vector3 v3_Target = cam.ScreenToWorldPoint(Input.mousePosition);

            //change camera size
            float CamSize = cam.orthographicSize - ScrollDelta;
            cam.orthographicSize = Mathf.Max(SizeMin, Mathf.Min(SizeMax, CamSize));

            //redraw lines
            if (GridManager != null)
                GridManager.GetComponent<DrawLines>().RedrawGrid();

            //get new mouse position, get difference, and move camera to keep mouse at same world position
            Vector3 v3_Source = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 v3_Diff = v3_Source - v3_Target;
            cam.transform.position -= new Vector3(v3_Diff.x, v3_Diff.y);
        }
    }
}
