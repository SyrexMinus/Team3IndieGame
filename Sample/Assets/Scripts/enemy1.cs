using System.Collections;
using UnityEngine;

// class of enemy 1
public class enemy1 : MonoBehaviour
{
    private float deadZoneRadius = 3;
    // target position
    protected float xt = 0, zt = 0;
    // speend on axes
    private float speedx, speedz;
    private float speed = 3;
    // lifes
    public int lifes;
    // chance 1 life
    public int chance1Life = 50;

    // when object spawns
    void Start()
    {
        int random = Random.Range(1, 100);
        if (random <= chance1Life)
            lifes = 1;
        else
            lifes = 2;
        // calculate speed
        CalculateSpeed();
    }

    void CalculateSpeed()
    {
        // get coordinates of object
        Vector3 position = transform.position;
        // set speed on x axis
        speedx = (xt - position.x) * speed / Mathf.Sqrt(Mathf.Pow(position.x - xt, 2) + Mathf.Pow(position.z - zt, 2));
        // set speed on z axis
        speedz = (zt - position.z) * speed / Mathf.Sqrt(Mathf.Pow(position.x - xt, 2) + Mathf.Pow(position.z - zt, 2));
    }
    // every frame do it
    void Update()
    {
        // destroy object if it got to the target
        if (Mathf.Pow(transform.position.x - xt, 2) + Mathf.Pow(transform.position.z - zt, 2) < Mathf.Pow(deadZoneRadius,2))
        {
            GameObject treasureObject;
            treasureObject = GameObject.Find("Treasure");
            Treasure treasureScript = (Treasure)treasureObject.GetComponent(typeof(Treasure));
            treasureScript.changeLifes(-1);
            Destroy(this.gameObject);
            return;
        } 
        // move object
        transform.position += new Vector3 (speedx * Time.deltaTime, 0, speedz * Time.deltaTime); 
    }

    public void Push(Vector3 vector)
    {
        transform.position += vector;
        CalculateSpeed();
    }

    // enemy get damaged
    public void Damage(int damage, Vector3 vector)
    {
        // change lifes
        lifes -= damage;
        // destroy object if lifes <= 0
        if(lifes <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        // push object if it is still alive
        else
        {
            Push(vector);
        }
    }
}