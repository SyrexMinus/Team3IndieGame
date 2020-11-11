using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sp :  MonoBehaviour
{
    // delta time between spawns
    public float minTimeBetweenSpawns;
    public float randomDeltaTimeBetweenSpawns;
    // current delta time between spawns
    private float currentTimeBetweenSpawns;
    // time has passed since the previous appearance
    private float timePassed;
    // boundaries of spawn
    public float x1, x2, z1, z2;
    // target coordinates
    private float xt, zt;
    // horizontal shift for player's fingers
    public float shiftz;
    // Template of enemy object
    public GameObject enemyObjectTemplate;
    // randomly make start position
    public Vector3 RandomCoordinatesOnBoundaries(float x1, float z1, float x2, float z2, float shiftz)
    {
        // get object position
        Vector3 position = transform.position;
        // randomly choose spawn zone
        int zoneNumber = (int)Mathf.Round(Random.Range(0.5f, 3.5f));
        // set coordinates
        switch (zoneNumber)
        {
            // left line
            case 1:
                position.x = x1;
                position.z = Random.Range(z1 + shiftz, z2);
                break;
            // top line
            case 2:
                position.z = z2;
                position.x = Random.Range(x1, x2);
                break;
            // right line
            case 3:
                position.x = x2;
                position.z = Random.Range(z1 + shiftz, z2);
                break;
        }

        return position;
    }

    // find treasure object and set xt and zt from this object coordinates
    public void ResetTargetCoordinates()
    {
        GameObject treasureObject = GameObject.Find("Treasure");
        Treasure treasureScript = (Treasure)treasureObject.GetComponent(typeof(Treasure));
        xt = treasureScript.transform.position.x;
        zt = treasureScript.transform.position.y;
    }

    void Start()
    {
        ResetTargetCoordinates();
    }

    // do in every frame
    void Update()
    {
        // update time passed after previous spawn
        timePassed += Time.deltaTime;
        // spawn enemy when time is come
        if (timePassed >= currentTimeBetweenSpawns)
        {
            // spawn new enemy
            Vector3 newVec = RandomCoordinatesOnBoundaries(x1, z1, x2, z2, shiftz);
            Instantiate(enemyObjectTemplate, newVec, Quaternion.identity);
            // update timer
            currentTimeBetweenSpawns = minTimeBetweenSpawns + Random.Range(0, randomDeltaTimeBetweenSpawns);
            timePassed = 0;
        }
    }
}
