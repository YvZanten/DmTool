using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    //import
    public GameObject EdgePrefab;
    public GameObject PointPrefab;

    //local
    public Point PointBegin;
    public Point PointEnd;

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
        if(Renderer != null && PointBegin != null)
            Renderer.SetPosition(0, PointBegin.ToVec3());

        if(Renderer != null && PointEnd != null)
            Renderer.SetPosition(1, PointEnd.ToVec3());
    }

    //Enable/disable outline of object
    public void ToggleOutline(bool show)
    {
        Renderer.enabled = show;
    }
}
