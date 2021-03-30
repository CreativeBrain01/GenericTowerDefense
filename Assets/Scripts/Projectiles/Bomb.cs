using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Projectile
{
    public GameObject explosion;

    public override void CollisionEvent()
    {
        GameObject go = Instantiate(explosion, transform.position, Quaternion.identity);
        go.GetComponent<Explosion>().damage = damage;

        base.CollisionEvent();
    }
}
