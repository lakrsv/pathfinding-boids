using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    private GameObject _player;
    public float Smooth;

	// Use this for initialization
	void Start () 
    {
        _player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
    {
        FollowPlayer();
	}
    void FollowPlayer()
    {
        var playerPos = _player.transform.position;
        var followPos = new Vector3(playerPos.x, transform.position.y, playerPos.z);

        transform.position = Vector3.Lerp(transform.position, followPos, Smooth * Time.deltaTime);
    }
}
