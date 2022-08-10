using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] toSpawn;

    float timeSinceLastSpawn = 0.0f;
    float timeUntilNextSpawn = 0.0f;
    public float minSpawnTime;
    public float maxSpawnTime;

    void Start()
    {
        timeUntilNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn > timeUntilNextSpawn)
        {
            GameObject spawned = Instantiate(toSpawn[Random.Range(0, toSpawn.Length)], transform.position, Quaternion.identity);
            int lane = Random.Range(1, 4);
            spawned.GetComponent<Entity>().lane = lane;
            float yCoord = 0.0f;
            if (spawned.CompareTag("Enemy"))
            {
                switch (lane)
                {
                    case 1:
                        yCoord = -3.0f;
                        break;
                    case 2:
                        yCoord = -2.05f;
                        break;
                    case 3:
                        yCoord = -1.15f;
                        break;
                    default:
                        yCoord = 0.0f;
                        break;
                }
            }
            else if (spawned.CompareTag("Juice Box"))
            {
                switch (lane)
                {
                    case 1:
                        yCoord = -3.5f;
                        break;
                    case 2:
                        yCoord = -2.6f;
                        break;
                    case 3:
                        yCoord = -1.7f;
                        break;
                    default:
                        yCoord = 0.0f;
                        break;
                }
            }
            spawned.transform.position = new Vector3(spawned.transform.position.x, yCoord, 0.0f);
            timeUntilNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;
        }
    }
}
