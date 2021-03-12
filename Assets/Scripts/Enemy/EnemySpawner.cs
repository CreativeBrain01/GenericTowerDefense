using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy spawnObj;
    public GameObject initialWaypoint;

    private int ct = 0; //# of enemies in the wave
    private float hp = 100; //Enemy HP for the wave
    private float spd = 30; //Enemy speed for the wave
    private float enemySpace = 3; //Delay between each enemy in a wave in seconds
    private float spawnTime = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) ct = 6;

        if (ct > 0)
        {
            if (spawnTime < enemySpace) spawnTime += Time.deltaTime;
            if (spawnTime >= enemySpace)
            {
                spawnObj.health = hp; spawnObj.speed = spd; spawnObj.target = initialWaypoint;
                Instantiate(spawnObj.gameObject);
                spawnTime = 0;
                ct--;
            }
        }
    }

    public void SpawnWave(int count, float health, float speed, float enemySpacing)
    {
        ct = count; hp = health; spd = 30; //30 for now as any higher and enemies don't work
        enemySpace = enemySpacing;
    }
}
