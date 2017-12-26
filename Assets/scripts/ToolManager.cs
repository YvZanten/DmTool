using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour {
    
    public enum ToolType { Grab, Rectangle};
    public ToolType CurrentTooltype;
    public Camera SceneCamera;

    private CameraDrag cd;

	// Use this for initialization
	void Start () {
        CurrentTooltype = ToolType.Grab;
        cd = SceneCamera.GetComponent<CameraDrag>();
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
