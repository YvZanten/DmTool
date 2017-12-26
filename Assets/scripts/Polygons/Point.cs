using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Vector2 Position;
    public float X
    {
        get
        {
            return Position != null ? Position.x : 0f;
        }

        set
        {
            if (Position != null)
                Position.x = value;

            UpdateEdges();
        }
    }           //public getter and setter of x coordinate, setting also calls 'UpdateEdges()'
    public float Y
    {
        get
        {
            return Position != null ? Position.y : 0f;
        }

        set
        {
            if (Position != null)
                Position.y = value;

            UpdateEdges();
        }
    }           //public getter and setter of y coordinate, setting also calls 'UpdateEdges()'

    public Edge EdgePrevious;   //reference to previous edge
    public Edge EdgeNext;       //reference to next edge

    public Point()
    {

    }

    // Use this for initialization
    void Start ()
    {
        Position = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    //updates values in next and previous edge
    private void UpdateEdges()
    {
        if (EdgePrevious != null)
            EdgePrevious.UpdateLine();

        if (EdgeNext != null)
            EdgeNext.UpdateLine();
    }

    //Enable/disable outline of object
    public void ToggleOutline(bool show)
    {

    }

    //returns this point position as vector3
    public Vector3 ToVec3()
    {
        return new Vector3(X, Y, 0);
    }
}
