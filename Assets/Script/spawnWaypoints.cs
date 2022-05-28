using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWaypoints : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject wayOne, wayTwo, wayThree;
    public float Radius = 1;
    // Start is called before the first frame update
    void Start()
    {
        RandomWaypoints();
    }

    void RandomWaypoints()
    {
        Vector3 spawnVector = new Vector3(spawnPoint.transform.position.x, 0, spawnPoint.transform.position.z);
        
        Vector3 randomPos = spawnVector + Random.insideUnitSphere * Radius;
        wayOne.transform.position = new Vector3(randomPos.x, 0, randomPos.z);

        Vector3 randomPos2 = spawnVector + Random.insideUnitSphere * Radius;
        wayTwo.transform.position = new Vector3(randomPos2.x, 0, randomPos2.z);

        Vector3 randomPos3 = spawnVector + Random.insideUnitSphere * Radius;
        wayThree.transform.position = new Vector3(randomPos3.x, 0, randomPos3.z);
    }
}
