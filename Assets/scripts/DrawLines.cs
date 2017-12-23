using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    //imports
    public Camera GameCamera;
    
    public GameObject GridLine;

    public int GridWidth;
    public int GridHeight;

    //local
    private LineRenderer[] GridArray_Vertical;
    private LineRenderer[] GridArray_Horizontal;

	// Use this for initialization
	void Start ()
    {
        //create lines
        CreateGrid();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void RedrawGrid()
    {
        
    }

    //Create LineRenderers
    private void CreateGrid()
    {
        //create vertical lines
        GridArray_Vertical = new LineRenderer[GridWidth];
        for (int index = 0; index < GridWidth; index++)
        {
            GameObject line = Instantiate(GridLine);
            LineRenderer lr = line.GetComponent<LineRenderer>();
            GridArray_Vertical[index] = lr;
            
            lr.SetPosition(0, new Vector3(-(GridWidth / 2) + index, -(GridHeight / 2), 0));
            lr.SetPosition(1, new Vector3(-(GridWidth / 2) + index, (GridHeight / 2), 0));

            line.transform.parent = this.transform;
        }

        //create horizontal lines
        GridArray_Horizontal = new LineRenderer[GridWidth];
        for (int index = 0; index < GridHeight; index++)
        {
            GameObject line = Instantiate(GridLine);
            LineRenderer lr = line.GetComponent<LineRenderer>();
            GridArray_Horizontal[index] = lr;
            
            lr.SetPosition(0, new Vector3(-(GridWidth / 2), -(GridHeight / 2) + index, 0));
            lr.SetPosition(1, new Vector3((GridWidth / 2), -(GridHeight / 2) + index, 0));

            line.transform.parent = this.transform;
        }
    }
}
