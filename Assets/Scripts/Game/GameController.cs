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
    public Text towerDescTxt;
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
            int EnemyCount = 2 * currentWave;
            int EnemyHP = 100; ;
            if (currentWave > 2)
            {
                EnemyHP = 100 + (50 * currentWave);
            } else
            if (currentWave == 1)
            {
                EnemyHP = 100;
            }
            else
            if (currentWave == 2)
            {
                EnemyHP = 125;
            }

            int EnemySpeed = 30; //static 30 until enemy rotation speed can be fixed.
            float TimeBetweenSpawns = 5 - (1 - (lives / maxLives));
            waves.SpawnWave(EnemyCount, EnemyHP, EnemySpeed, TimeBetweenSpawns);
        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                score += 100;
            }
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

        Tower tower = TowerPlacer.tower.GetComponent<Tower>();

        string desc = tower.Description + "\n\n" + 
            "*" + tower.SplashText + "*\n\n" +
            "Range: " + tower.range + "\n" +
            "Damage: " + tower.damage + "\n" +
            "Firerate: " + tower.fireRate + "\n" +
            "Turret Cost: " + tower.towerCost;

        towerDescTxt.text = desc;
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
        }
        else if (rightVal <= -2)
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
