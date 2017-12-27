using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    //import
    public GameObject ToolMenu;
    public Camera SceneCamera;

    public enum ToolType { Grab, Rectangle, MovePoint, Cut};
    public ToolType CurrentTooltype;

    private CameraDrag cd;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeToolType(int tool)
    {
        CurrentTooltype = (ToolType)tool;
        Debug.Log(tool.ToString());
    }
}
