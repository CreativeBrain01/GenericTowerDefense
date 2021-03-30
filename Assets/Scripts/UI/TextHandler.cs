using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    public EnemySpawner waves;

    public Text livesTxt;
    public Text scoreTxt;
    public Text waveTxt;
    public Text enemiesTxt;
    public Text towerDescTxt;
    public GameObject nextWaveTxt;
    public GameObject rangeCtrlTxt;

    private void Start()
    {
        nextWaveTxt.GetComponent<Text>().text = "Press [" + GameController.nextWaveControl + "] to start next wave.";
        rangeCtrlTxt.GetComponent<Text>().text = "Not sure how far a tower shoots? Hover over it and hold[" + GameController.viewRangeControl + "].";
    }

    void Update()
    {
        livesTxt.text = "Lives: " + GameController.lives;
        scoreTxt.text = "Score: " + GameController.score;
        waveTxt.text = "Wave: " + GameController.GetWave;
        int EnemiesLeft = waves.EnemiesLeft + FindObjectsOfType<Enemy>().Length;
        enemiesTxt.text = "Enemies Left: " + EnemiesLeft;
        nextWaveTxt.SetActive(waves.EnemiesLeft <= GameController.maxEnemies);

        Tower tower = TowerPlacer.tower.GetComponent<Tower>();

        string desc = tower.Description + "\n\n" +
            "*" + tower.SplashText + "*\n\n" +
            "Range: " + tower.range + "\n" +
            "Damage: " + tower.damage + "\n" +
            "Firerate: " + tower.fireRate + "\n" +
            "Turret Cost: " + tower.towerCost;

        towerDescTxt.text = desc;

        if (GameController.GetWave >= 5)
        {
            rangeCtrlTxt.SetActive(false);
            nextWaveTxt.transform.position = rangeCtrlTxt.transform.position;
        }
    }
}
