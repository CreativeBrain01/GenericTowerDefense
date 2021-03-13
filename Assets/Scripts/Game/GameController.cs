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
    public GameObject nextWaveTxt;
    public EnemySpawner waves;

    public static int score = 100;
    public static int lives = 100;

    private static int currentWave = 0;
    private static int maxLives = 100;
    private static int maxEnemies = 5;

    private void Start()
    {
        maxLives = lives;
    }

    private void Update()
    {
        UpdateUI();

        if (Input.GetKeyDown(KeyCode.Space) && waves.EnemiesLeft <= maxEnemies)
        {
            currentWave++;
            int EnemyCount = currentWave * 2;
            int EnemyHP = 100 + (35 * (currentWave - 1));
            int EnemySpeed = 30; //static 30 until enemy rotation speed can be fixed.
            float TimeBetweenSpawns = 5 + lives / maxLives;
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
    }
}
