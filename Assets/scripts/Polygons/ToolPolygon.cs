using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPolygon : MonoBehaviour
{
    //import
    public GameObject PolygonPrefab;

    //local
    public Camera GameCamera;

    private bool CreatingPoly = false;

    private Vector3 v3_MouseStart;
    private Vector3 v3_MouseNow;

    private GameObject PolygonObject;
    private Polygon CurrentPolygon;

	// Use this for initialization
	void Start ()
    {
        GameCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            CreatingPoly = true;

            v3_MouseStart = GameCamera.ScreenToWorldPoint(Input.mousePosition);

            PolygonObject = Instantiate(PolygonPrefab);             //instantiate  prefab
            CurrentPolygon = PolygonObject.GetComponent<Polygon>(); //get polygon component
            CurrentPolygon.SetupPointsAndEdges(true);               //setup polygon lists
            foreach (Point p in CurrentPolygon.Points)
            {
                p.X = v3_MouseStart.x;
                p.Y = v3_MouseStart.y;
            }
        }
        else if (Input.GetMouseButtonUp(0))
            CreatingPoly = false;

        if(CreatingPoly)
        {
            v3_MouseNow = GameCamera.ScreenToWorldPoint(Input.mousePosition);
            CurrentPolygon.Points[1].X = v3_MouseNow.x;

            CurrentPolygon.Points[3].Y = v3_MouseNow.y;

            CurrentPolygon.Points[2].X = v3_MouseNow.x;
            CurrentPolygon.Points[2].Y = v3_MouseNow.y;
        }
	}
}
