using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_sp :  MonoBehaviour
{
    // delta time between spawns
    public float minTimeBetweenSpawns = 1.5f;
    public float randomDeltaTimeBetweenSpawns = 1.0f;
    // current delta time between spawns
    private float currentTimeBetweenSpawns = 0.0f;
    // time has passed since the previous appearance
    private float timePassed = 0.0f;
    // boundaries of spawn
    public int x1 = -50, x2 = 50, z1 = -50, z2 = 50, xt = 0, zt = 0;
    // horizontal shift for player's fingers
    public int shiftz = 20;
    // Template of enemy object
    public GameObject enemyObjectTemplate;
    // randomly make start position
    public Vector3 RandomCoordinatesOnBoundaries(int x1, int z1, int x2, int z2, int shiftz)
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
    // create new enemy object 
    void Start()
    {
        // create copy of enemyObjectTemplate with coordinates setRandomCoordinatesOnBoundaries and with parents coordinates basis
        Instantiate(enemyObjectTemplate, RandomCoordinatesOnBoundaries(x1, z1, x2, z2, shiftz), Quaternion.identity); 
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
