using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelHandler : MonoBehaviour
{
    // Players and enemies
    public GameObject GoblinPrefab;
    public GameObject HeadcutterPrefab;
    public GameObject PlayerCharacter;

    public GameObject spawnPoint;
    public TextMeshProUGUI stageDisplay;

    // Waypoints for Goblins to follow
    public Transform wayOne, wayTwo, wayThree;
    public float waypointRadius = 10;

    public HealthBar PlayerHealthBar;

    // Variable for stage count handler
    public int stage;
    public int stageUncleared;

    public float Radius = 25;
    // Start is called before the first frame update
    void Start()
    {
        stage = 1;
        SpawnGoblin(1 + stage);
        SpawnHeadcutter(1);
    }

    private void Update()
    {
        stageUncleared = stage - 1;
        stageDisplay.SetText(stageUncleared.ToString());
    }

    void SpawnGoblin(int numEnemies)
    {
        //Vector2 spawnVector = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.z);
        for (int i = 0; i < numEnemies; i++)
        {
            Vector3 toCircle = Random.insideUnitCircle;
            toCircle = new Vector3(toCircle.x, 0, toCircle.y);
            Vector3 randomPos = spawnPoint.transform.position + toCircle * Radius;
            Instantiate(GoblinPrefab, randomPos, Quaternion.identity);
            //RandomWaypoints(randomPos);
        }
    }

    void SpawnHeadcutter(int numEnemies)
    {
        //Vector2 spawnVector = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.z);
        for (int i = 0; i < numEnemies; i++)
        {
            Vector3 toCircle = Random.insideUnitCircle;
            toCircle = new Vector3(toCircle.x, 0, toCircle.y);
            Vector3 randomPos = spawnPoint.transform.position + toCircle * Radius;
            Instantiate(HeadcutterPrefab, randomPos, Quaternion.identity);
            //RandomWaypoints(randomPos);
        }
    }

    public void NextStage()
    {
        stage++;
        PlayerCharacter.transform.position = new Vector3(31.37611f, 3.384f, 11.79501f);
        PlayerCharacter.transform.eulerAngles = new Vector3(0, 0, 0);
        SpawnGoblin(1 + stage);

        PlayerCharacter.GetComponent<PlayerCombat>().currentHealth = 100;
        PlayerHealthBar.SetHealth(100);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, Radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, waypointRadius);
    }

    void RandomWaypoints(Vector3 enemySpawn)
    {
        Vector3 randomPos = enemySpawn + Random.insideUnitSphere * waypointRadius;
        wayOne.transform.position = new Vector3(randomPos.x, 0, randomPos.z);

        Vector3 randomPos2 = enemySpawn + Random.insideUnitSphere * waypointRadius;
        wayTwo.transform.position = new Vector3(randomPos2.x, 0, randomPos2.z);

        Vector3 randomPos3 = enemySpawn + Random.insideUnitSphere * waypointRadius;
        wayThree.transform.position = new Vector3(randomPos3.x, 0, randomPos3.z);
    }
}
