using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public EnemySpawner waves;
    public Tower startingTower;

    public static int score = 100;
    public static int lives = 100;
    public static int maxEnemies = 5;

    public static KeyCode nextWaveControl = KeyCode.Space;
    public static KeyCode viewRangeControl = KeyCode.LeftShift;

    private static int currentWave = 0;
    private static int maxLives = 100;

    public static int GetWave { get { return currentWave; } }

    private void Start()
    {
        maxLives = lives;
        TowerPlacer.SetTower(startingTower.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(nextWaveControl) && waves.EnemiesLeft <= maxEnemies)
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
}
