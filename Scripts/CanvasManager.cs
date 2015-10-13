using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasManager : MonoBehaviour {
    private Text _enemiesKilledText;
    private int _enemiesKilledCount;
    private Text _grenadeText, _mineText;
    public int GrenadeCount, MineCount;
    public int EnemiesKilledCount
    {
        get
        {
            return _enemiesKilledCount;
        }
    }

	// Use this for initialization
	void Start () 
    {
        _enemiesKilledCount = 0;
        _enemiesKilledText = gameObject.transform.GetChild(0).GetComponent<Text>();
        _grenadeText = gameObject.transform.GetChild(1).GetComponent<Text>();
        _mineText = gameObject.transform.GetChild(2).GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void UpdateKillCountText()
    {
        _enemiesKilledCount += 1;
        _enemiesKilledText.text = string.Format("Enemies Killed: {0}", _enemiesKilledCount);
    }
    public void UpdateAmmoCount(string type)
    {
        switch (type)
        {
            case "Grenade":
                GrenadeCount -= 1;
                _grenadeText.text = string.Format("Grenades: {0}", GrenadeCount);
                break;
            case "Mine":
                MineCount -= 1;
                _mineText.text = string.Format("Mines: {0}", MineCount);
                break;
        }
    }
    public void SetTextCount()
    {
        _mineText.text = string.Format("Mines: {0}", MineCount);
        _grenadeText.text = string.Format("Grenades: {0}", GrenadeCount);
        _enemiesKilledText.text = string.Format("Enemies Killed: {0}", _enemiesKilledCount);
    }
}
