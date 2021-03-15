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
    public GameObject viewRangeTxt;

    void Update()
    {
        livesTxt.text = "Lives: " + GameController.lives;
        scoreTxt.text = "Score: " + GameController.score;
        waveTxt.text = "Wave: " + GameController.GetWave;
        int EnemiesLeft = waves.EnemiesLeft + FindObjectsOfType<Enemy>().Length;
        enemiesTxt.text = "Enemies Left: " + EnemiesLeft;
        string newWaveText = "Press [" + GameController.nextWaveKey.ToString() + "] to start next wave.";
        nextWaveTxt.SetActive(waves.EnemiesLeft <= waves.maxEnemies);

        Tower tower = TowerPlacer.tower.GetComponent<Tower>();

        string desc = tower.Description + "\n\n" +
            "*" + tower.SplashText + "*\n\n" +
            "Range: " + tower.range + "\n" +
            "Damage: " + tower.damage + "\n" +
            "Firerate: " + tower.fireRate + "\n" +
            "Turret Cost: " + tower.towerCost;

        towerDescTxt.text = desc;

        if (GameController.GetWave > 5)
        {
            viewRangeTxt.SetActive(false);
            nextWaveTxt.transform.position = viewRangeTxt.transform.position;
        }
    }
}
