using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : MonoBehaviour
{
    enum ShapeType
    {
        SHAPE_RECT,
        SHAPE_POLYGON,
    };

    //import
    public GameObject EdgePrefab;
    public GameObject PointPrefab;

    //local
    public List<Point> Points;     //List of points in this polygon
    public List<Edge> Edges;       //List of edges in this polygon

    Texture2D Texture;              //Texture to be displayed on this polygon
    float TextureRotation;          //Rotation of texture

    ShapeType Shape;                //ShapeType of this object

	// Use this for initialization
	void Start ()
    {
        Points = new List<Point>(4);
        Edges = new List<Edge>(4);
        for (int index = 0; index < 4; index++)
        {
            GameObject Point = Instantiate(PointPrefab);
            Point.transform.parent = this.transform;
            Points.Add(Point.GetComponent<Point>());

            GameObject Edge = Instantiate(EdgePrefab);
            Edge.transform.parent = this.transform;
            Edges.Add(Edge.GetComponent<Edge>());
        }

        for(int index = 0; index < 4; index++)
        {
            Points[index].EdgePrevious = Edges[(index + 3) % 4];
            Points[index].EdgeNext = Edges[index];

            Edges[index].Begin = Points[index];
            Edges[index].End = Points[(index + 1) % 4];
        }

        Texture = new Texture2D(1, 1);
        TextureRotation = 0f;
        Shape = ShapeType.SHAPE_RECT;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //Enable/disable outline of object
    public void ToggleOutline(bool show)
    {

    }
}
