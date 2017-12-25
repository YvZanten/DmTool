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

    //Create LineRenderers
    private void CreateGrid()
    {
        //create vertical lines
        GridArray_Vertical = new LineRenderer[GridWidth + 1];
        for (int index = 0; index < GridWidth + 1; index++)
        {
            GameObject line = Instantiate(GridLine);
            LineRenderer lr = line.GetComponent<LineRenderer>();
            GridArray_Vertical[index] = lr;

            lr.SetPosition(0, new Vector3(-(GridWidth / 2) + index, -(GridHeight / 2), 0));
            lr.SetPosition(1, new Vector3(-(GridWidth / 2) + index, (GridHeight / 2), 0));

            lr.name = "LR VER " + index;

            line.transform.parent = this.transform;
        }

        //create horizontal lines
        GridArray_Horizontal = new LineRenderer[GridWidth + 1];
        for (int index = 0; index < GridHeight + 1; index++)
        {
            GameObject line = Instantiate(GridLine);
            LineRenderer lr = line.GetComponent<LineRenderer>();
            GridArray_Horizontal[index] = lr;

            lr.SetPosition(0, new Vector3(-(GridWidth / 2), -(GridHeight / 2) + index, 0));
            lr.SetPosition(1, new Vector3((GridWidth / 2), -(GridHeight / 2) + index, 0));

            lr.name = "LR HOR " + index;

            line.transform.parent = this.transform;
        }

        //Redraw lines once to get right width
        RedrawGrid();
    }

    public void RedrawGrid()
    {
        //get zoomlevel depending in camera size
        float Zoomfactor = GameCamera.orthographicSize;
        int ZoomLevel = 0;
        if (Zoomfactor >= 15 && Zoomfactor < 40)
            ZoomLevel = 1;
        else if (Zoomfactor >= 40)
            ZoomLevel = 2;

        ///lvl0
        ///all lines are small, (1 px)
        ///lvl1
        ///4th lines are medium (2 px), all others small (1 px)
        ///lvl2
        ///4th lines are medium (1 px), all others large (2 px)
        float pixelWidth = (GameCamera.ScreenToWorldPoint(Vector3.zero) - GameCamera.ScreenToWorldPoint(new Vector3(1, 0, 0))).x;   //find world width for 1 screen pixel width
        float Width_Small = ZoomLevel == 2 ? 0.0f : pixelWidth * -1;
        float Width_Medium = ZoomLevel == 2 ? pixelWidth * -1 : pixelWidth * -2;
        float Width_Large = pixelWidth * -2;

        //set width of all vertical lines
        for (int index = 0; index < GridWidth + 1; index++)
        {
            GridArray_Vertical[index].startWidth = GridArray_Vertical[index].endWidth = Width_Small;        //set width of all lines initially to small
            if(ZoomLevel == 1 && (index + 1) % 2 == 0)                                                      //if at lvl1, remove (2n + 1)th line
                GridArray_Vertical[index].startWidth = GridArray_Vertical[index].endWidth = 0;              
            if (ZoomLevel != 0 && index % 4 == 0)                                                           //if not lvl0, every 4th line is medium
                GridArray_Vertical[index].startWidth = GridArray_Vertical[index].endWidth = Width_Medium;
            if (ZoomLevel == 2 && index % 16 == 0)                                                          //if lvl2, every 16th line is large
                GridArray_Vertical[index].startWidth = GridArray_Vertical[index].endWidth = Width_Large;
        }

        //set width of all horizontal lines
        for (int index = 0; index < GridHeight + 1; index++)
        {
            GridArray_Horizontal[index].startWidth = GridArray_Horizontal[index].endWidth = Width_Small;        //set width of all lines initially to small
            if (ZoomLevel == 1 && (index + 1) % 2 == 0)                                                         //if at lvl1, remove (2n + 1)th line
                GridArray_Horizontal[index].startWidth = GridArray_Horizontal[index].endWidth = 0;
            if (ZoomLevel != 0 && index % 4 == 0)                                                               //if not lvl0, every 4th line is medium
                GridArray_Horizontal[index].startWidth = GridArray_Horizontal[index].endWidth = Width_Medium;
            if (ZoomLevel == 2 && index % 16 == 0)                                                              //if lvl2, every 16th line is large
                GridArray_Horizontal[index].startWidth = GridArray_Horizontal[index].endWidth = Width_Large;
        }
    }
}
