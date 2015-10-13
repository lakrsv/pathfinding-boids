using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject Enemy;
    private EnemyCorreographer _enemyCor;

	// Use this for initialization
	void Start () 
    {
        Invoke("InstantiateEnemies", 5F);
        _enemyCor = GameObject.FindGameObjectWithTag("Correographer").GetComponent<EnemyCorreographer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        CountEnemies();
	}
    void InstantiateEnemies()
    {
        for (int i = 0; i < 100; i++)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
    }
    void CountEnemies()
    {
        if (_enemyCor != null)
        {
            if (_enemyCor.EnemyCount < 1)
            {
                InstantiateEnemies();
            }
        }
    }
}
