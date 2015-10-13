using UnityEngine;
using System.Collections;

public class GrenadeMasterTimer : MonoBehaviour {
    public GameObject Explosion;
    public int ExplodeTimer;

	// Use this for initialization
	void Start () 
    {
        Invoke("Explode", ExplodeTimer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Explode()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void ExplodeDelay()
    {
        Invoke("Explode", 0.2F);
    }
}
