using UnityEngine;
using System.Collections;

public class MineScript : MonoBehaviour
{
    private bool _isEnabled = false;
    public GameObject Explosion;
    public float ActivationTime;
    void Start()
    {
        Invoke("EnableMine", ActivationTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (_isEnabled)
        {
            if (other.transform.tag == "Enemy" || other.transform.tag == "Player")
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    void EnableMine()
    {
        _isEnabled = true;
    }
}
