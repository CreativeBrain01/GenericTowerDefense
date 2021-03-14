using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text livesTxt;
    public Text scoreTxt;
    public Text waveTxt;
    public Text enemiesTxt;
    public Text towerCostTxt;
    public GameObject nextWaveTxt;
    public EnemySpawner waves;
    public Tower startingTower;

    public static int score = 100;
    public static int lives = 100;

    private static int currentWave = 0;
    private static int maxLives = 100;
    private static int maxEnemies = 5;

    private void Start()
    {
        maxLives = lives;
        TowerPlacer.SetTower(startingTower.gameObject);
    }

    private void Update()
    {
        UpdateUI();

        if (Input.GetKeyDown(KeyCode.Space) && waves.EnemiesLeft <= maxEnemies)
        {
            currentWave++;
            int EnemyCount = 2;
            EnemyCount = (int)Exponent(EnemyCount, currentWave);

            int EnemyHP = 100 + (25 * (int)Exponent(1.25, currentWave));
            int EnemySpeed = 30; //static 30 until enemy rotation speed can be fixed.
            float TimeBetweenSpawns = 5 - (1 - (lives / maxLives));
            waves.SpawnWave(EnemyCount, EnemyHP, EnemySpeed, TimeBetweenSpawns);
        }
    }

    private void UpdateUI()
    {
        livesTxt.text = "Lives: " + lives;
        scoreTxt.text = "Score: " + score;
        waveTxt.text = "Wave: " + currentWave;
        int EnemiesLeft = waves.EnemiesLeft + FindObjectsOfType<Enemy>().Length;
        enemiesTxt.text = "Enemies Left: " + EnemiesLeft;
        nextWaveTxt.SetActive(waves.EnemiesLeft <= maxEnemies);
        towerCostTxt.text = "Tower Cost: " + TowerPlacer.tower.GetComponent<Tower>().towerCost;
    }

    public static double Exponent(double leftVal, int rightVal)
    {
        if (rightVal == 0) return 1;
        if (rightVal == 1) return leftVal;
        if (rightVal == -1) return 1 / leftVal;

        double result = leftVal;
        if (rightVal >= 2)
        {
            for (int i = 1; i < rightVal; i++)
            {
                result *= leftVal;
            }
        } else if (rightVal <= -2)
        {
            for (int i = -1; i > rightVal; i--)
            {
                result *= leftVal;
            }
            result = 1 / result;
        }

        return result;
    }
}
