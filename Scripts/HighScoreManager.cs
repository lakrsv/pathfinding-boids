using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {
    private Text _highScoreText;

	// Use this for initialization
	void Start () 
    {
        if (Application.loadedLevel == 0)
        {
            _highScoreText = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<Text>();
            _highScoreText.text = string.Format("HighScore: {0}", GetHighScore());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetHighScore(int currentscore)
    {
        if (currentscore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", currentscore);
        }
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
}
