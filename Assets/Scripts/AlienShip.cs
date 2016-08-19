using System;
using UnityEngine;
using System.Collections;

public class AlienShip : MonoBehaviour
{

    public float Speed;
    public float Range;
    public GameObject Explosion;

    void Update()
    {
        Move();
        CheckRange();
    }

    // Occurs when objects collide.
    // If any of colliding objects has this method defined, 
    // then it is called
    // And obviously AlienShip has to die on collision
    void OnCollisionEnter2D(Collision2D other)
    {
        if (IsLaserBullet(other))
            Die();
    }


    // If the object is out of range 
    // if (this.transform.position.y < Range)
    // then just get rid of it
    // Destroy (this.gameObject);
    void CheckRange()
    {
        if (this.transform.position.y < Range)
            Destroy(this.gameObject);
    }


    // If we want to prevent friendly alien deathes then 
    // we shoud assume that aliens die only on laser bullet collision
    // return other.gameObject.tag == "LaserBullet";
    bool IsLaserBullet(Collision2D other)
    {
        return (other.gameObject.tag == "LaserBullet");
    }


    // As aliens move down then dY should be
    // var dy = -1 * Speed * Time.deltaTime;
    // and to move the object we'll use a translate method
    // this.transform.Translate (0, dy , 0); 
    void Move()
    {
        var dy = -1 * Speed * Time.deltaTime;
        this.transform.Translate(0, dy, 0);
    }

    // To kill the alien, it is enough to remove the game object
    // Destroy (this.gameObject);
    // But to make it spectacular
    // Lets spawn an Explosion
    // SpawnExplosion ();
    void Die()
    {
        Destroy(gameObject);
        SpawnExplosion();
    }


    // Spawning explosion is quite simple
    // var explosion = Instantiate (Explosion, this.transform.position, Quaternion.identity) as GameObject;
    // Just don't forget to assign the parent
    // explosion.transform.parent = this.transform.parent;
    void SpawnExplosion()
    {
        var explosion = Instantiate(Explosion, this.transform.position, Quaternion.identity) as GameObject;
        explosion.transform.parent = this.transform.parent;
    }

}
