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

    //local
    List<Point> Points;     //List of points in this polygon
    List<Edge> Edges;       //List of edges in this polygon
    Texture2D Texture;      //Texture to be displayed on this polygon
    float TextureRotation;  //Rotation of texture
    ShapeType Shape;        //ShapeType of this object

	// Use this for initialization
	void Start ()
    {
        Points = new List<Point>();
        Edges = new List<Edge>();
        Texture = new Texture2D(1, 1);
        TextureRotation = 0f;
        Shape = ShapeType.SHAPE_RECT;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //Enable/disable outline of object
    void ToggleOutline(bool show)
    {

    }
}
