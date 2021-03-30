using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage { get; set; }
    public float maxSize = 100;
    public float growth = 5;

    private List<Enemy> StruckEnemies = new List<Enemy>();

    public void Update()
    {
        if (transform.localScale.x < maxSize)
        {
            float trueGrowth = growth * Time.deltaTime;
            transform.localScale += new Vector3(trueGrowth, trueGrowth, trueGrowth);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                StruckEnemies.Add(enemy);
            }
        }
    }

    public bool HasHit(Enemy enemy)
    {
        foreach (Enemy E in StruckEnemies)
        {
            if (E == enemy) return true;
        }

        return false;
    }
}
