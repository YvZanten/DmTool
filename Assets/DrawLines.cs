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
    private const int GridCellSize = 64;

    private LineRenderer[] GridArray_Vertical;
    private LineRenderer[] GridArray_Horizontal;

	// Use this for initialization
	void Start ()
    {
        Debug.unityLogger.Log("shop", GridWidth.ToString());

        //create lines
        Debug.unityLogger.Log("", "got width as thick as " + GridWidth);
        CreateLines();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //Create LineRenderers
    private void CreateLines()
    {
        //create vertical lines
        GridArray_Vertical = new LineRenderer[GridWidth];
        for (int index = 0; index < GridWidth; index++)
        {
            GameObject line = Instantiate(GridLine);
            LineRenderer lr = line.GetComponent<LineRenderer>();
            GridArray_Vertical[index] = lr;

            //position size already set to 2 by Prefab
            lr.SetPosition(0, GameCamera.ScreenToWorldPoint(
                new Vector3(
                    (index - GridWidth / 2 + 1) * GridCellSize, 
                    -(GridHeight / 2 * GridCellSize), 
                    -(GameCamera.transform.position.z)
                    )));

            lr.SetPosition(1, GameCamera.ScreenToWorldPoint(
                new Vector3(
                    (index - GridWidth / 2 + 1) * GridCellSize, 
                    +(GridHeight / 2 * GridCellSize), 
                    -(GameCamera.transform.position.z)
                    )));

            line.transform.parent = this.transform;
        }

        //create horizontal lines
        GridArray_Horizontal = new LineRenderer[GridWidth];
        for (int index = 0; index < GridHeight; index++)
        {
            GameObject line = Instantiate(GridLine);
            LineRenderer lr = line.GetComponent<LineRenderer>();
            GridArray_Horizontal[index] = lr;

            //position size already set to 2 by Prefab
            lr.SetPosition(0, GameCamera.ScreenToWorldPoint(
                new Vector3(
                    -(GridWidth / 2 * GridCellSize), 
                    (index - GridHeight / 2 + 1) * GridCellSize, 
                    -(GameCamera.transform.position.z)
                    )));

            lr.SetPosition(1, GameCamera.ScreenToWorldPoint(
                new Vector3(
                    +(GridWidth / 2 * GridCellSize), 
                    (index - GridHeight / 2 + 1) * GridCellSize, 
                    -(GameCamera.transform.position.z)
                    )));

            line.transform.parent = this.transform;
        }
    }
}
