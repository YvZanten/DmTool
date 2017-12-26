using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Vector2 Position;
    public float X { get { return Position != null ? Position.x : 0f; } }
    public float Y { get { return Position != null ? Position.y : 0f; } }
    Edge Previous;
    Edge Next;

    // Use this for initialization
    void Start ()
    {
		
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
