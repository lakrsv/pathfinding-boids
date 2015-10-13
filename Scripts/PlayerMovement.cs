using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float _inputH, _inputV, _speedMod, _maxSpeed;
    private Rigidbody _myRigidBody;
    private Vector3 _movementVector;
	// Use this for initialization
	void Start () 
    {
        _myRigidBody = GetComponent<Rigidbody>();
        _speedMod = 10;
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayerMove();
	}
    void PlayerMove()
    {
        _movementVector = new Vector3(_inputH, 0,  _inputV);
        _inputH = Input.GetAxis("Horizontal");
        _inputV = Input.GetAxis("Vertical");
        _myRigidBody.velocity = _movementVector.normalized * _speedMod;
    }
}
