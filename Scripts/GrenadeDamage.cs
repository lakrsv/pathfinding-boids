using UnityEngine;
using System.Collections;

public class GrenadeDamage : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        ApplyExplosionDamage();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void ApplyExplosionDamage()
    {
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, 2);
        for (int i = 0; i < hitObjects.Length; i++)
        {
            if (hitObjects[i].transform.tag == "Enemy")
            {
                hitObjects[i].GetComponent<EnemyAI>().TakeDamage(20);
            }
            else if (hitObjects[i].transform.tag == "Player")
            {
                hitObjects[i].GetComponent<PlayerHealth>().TakeDamage(20);
            }
            else if (hitObjects[i].transform.tag == "GrenadeMaster")
            {
                hitObjects[i].GetComponent<GrenadeMasterTimer>().ExplodeDelay();
            }
        }
    }
    //void OnCollisionEnter(Collision other)
    //{
    //    foreach (ContactPoint contactPoint in other.contacts)
    //    {
    //        var collObject = contactPoint.otherCollider.gameObject;
    //        if (collObject.transform.tag == "Enemy")
    //        {
    //            collObject.GetComponent<EnemyAI>().TakeDamage(20);
    //        }
    //        else if (collObject.transform.tag == "Player")
    //        {
    //            collObject.GetComponent<PlayerHealth>().TakeDamage(20);
    //        }
    //        if (collObject.transform.tag == "GrenadeMaster")
    //        {
    //            collObject.GetComponent<GrenadeMasterTimer>().Explode();
    //        }
    //    }
    //}
}
