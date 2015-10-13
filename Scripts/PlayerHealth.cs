using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int Health;
    private Vector3 _startPosition;

	// Use this for initialization
	void Start () 
    {
        Health = 100;
        _startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            HighScoreManager highScoreMan = GameObject.FindGameObjectWithTag("HighScoreManager").GetComponent<HighScoreManager>();
            var currentScore = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasManager>().EnemiesKilledCount;
            highScoreMan.SetHighScore(currentScore);
            Application.LoadLevel(0);
        }
    }
}
