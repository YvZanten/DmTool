using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    //import
    public GameObject EdgeObject;
    public GameObject PointObject;

    //local
    public Point Begin;
    public Point End;

    private LineRenderer Renderer;

	// Use this for initialization
	void Start ()
    {
        Renderer = GetComponent<LineRenderer>();
        Renderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    //called from outside this object, updates line renderer
    public void UpdateLine()
    {
        Renderer.SetPosition(0, Begin.ToVec3());
        Renderer.SetPosition(1, End.ToVec3());
    }

    //Enable/disable outline of object
    public void ToggleOutline(bool show)
    {
        Renderer.enabled = show;
    }
}
