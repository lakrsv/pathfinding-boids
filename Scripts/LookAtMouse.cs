using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {
    private MouseHandler MouseHandle;

	// Use this for initialization
	void Start () 
    {
        MouseHandle = transform.root.GetComponent<MouseHandler>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        MouseLook();
	}
    void MouseLook()
    {
        var mouseCursor = MouseHandle.MouseCursor;
        var lookPos = new Vector3(mouseCursor.transform.position.x, 0, mouseCursor.transform.position.z);
        var myTempPos = new Vector3(transform.position.x, 0, transform.position.z);
        transform.rotation = Quaternion.LookRotation((lookPos - myTempPos).normalized);
    }
}
