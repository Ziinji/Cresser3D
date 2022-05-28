using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject GoblinPrefab;
    public GameObject spawnPoint;
    public int stage;
    public float Radius = 1;
    // Start is called before the first frame update
    void Start()
    {
        stage = 1;
        SpawnGoblin(stage*3 + 1);
    }

    private void Update()
    {
        
    }

    void SpawnGoblin(int numEnemies)
    {
        Vector2 spawnVector = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.z);
        for (int i = 0; i < numEnemies; i++)
        {
            Vector2 randomPos = spawnVector + Random.insideUnitCircle * Radius;
            Instantiate(GoblinPrefab, randomPos, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}
