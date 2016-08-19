using UnityEngine;

public class LaserBullet : MonoBehaviour
{

    public float Range;
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckRange();
    }


    // to move the bullet we calculate dY
    // float deltaY = Speed * Time.deltaTime;
    // this.transform.Translate (0, deltaY, 0);

    void Move()
    {
        float deltaY = Speed * Time.deltaTime;
        this.transform.Translate(0, deltaY, 0);
    }


    // ah and when the object has left our warzone let's destroy it
    // if (this.transform.position.y > Range)
    // Destroy (this.gameObject);

    void CheckRange()
    {
        if (this.transform.position.y > Range)
            Destroy(this.gameObject);
    }
}
