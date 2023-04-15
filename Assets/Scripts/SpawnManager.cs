using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyObj;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int enemycount;
    public int spawnCount;

    public List<Enemy> enemies= new List<Enemy>();
    public Enemy[] enemiesCurrent;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(spawnCount);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        //enemycount = FindObjectsOfType<EnemyController>(enemyObj).Length;
        enemiesCurrent = FindObjectsOfType<Enemy>();
        enemycount = enemiesCurrent.Length;

        if (enemycount == 0)
        {
            spawnCount++;
            SpawnEnemyWave(spawnCount);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //Instantiate(enemyObj, GenerateSpawnPosition(), enemyObj.transform.rotation);
            index = Random.Range(0, enemies.Count);
            Instantiate(enemies[index], GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

}
