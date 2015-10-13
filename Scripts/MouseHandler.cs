using UnityEngine;
using System.Collections;

public class MouseHandler : MonoBehaviour {
    private Vector3 _mousePos;
    public GameObject MouseCursor;

	// Use this for initialization
	void Start () 
    {
        MouseCursor = new GameObject();
        MouseCursor.name = "MouseCursor";
	}
	
	// Update is called once per frame
	void Update () 
    {
        MousePos();
	}
    void MousePos()
    {
        Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit MouseHit;
        if (Physics.Raycast(MouseRay, out MouseHit))
        {
            _mousePos = MouseHit.point;
            MouseCursor.transform.position = _mousePos;
        }
    }
}
