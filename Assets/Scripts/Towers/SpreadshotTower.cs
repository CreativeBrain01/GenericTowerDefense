using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadshotTower : Tower
{
    protected override void Fire(List<GameObject> inRange)
    {
        foreach (GameObject target in inRange)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z);
            Projectile newProj = GameObject.Instantiate<GameObject>(projectile, spawnPos, Quaternion.identity).GetComponent<Projectile>();
            newProj.target = target;
            newProj.damage = damage;
        }
    }
}
