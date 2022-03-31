using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject enemyRow;
    [SerializeField] private int extraSpawnChance;
    private List<Transform> cubeList = new List<Transform>();

    public bool isEnemySpawner;
    private bool isRowSpawningActive;
    private bool mustSpawn = true;
    private int extraHeight = 0;

    private void Awake()
    {
        if (isEnemySpawner)
            isRowSpawningActive = true;
    }

    void Start()
    {
        GameManager.instance.GameStarted += StartSpawning;
    }

    private void OnDestroy()
    {
        GameManager.instance.GameStarted -= StartSpawning;
    }

    public void StartSpawning()
    {
        if (!isEnemySpawner)
        {
            int spawnChance = Random.Range(0, 100);
            if(spawnChance + extraSpawnChance >= 50)
            {
                float xPos = Random.Range(-1.5f, 1.7f);
                Vector3 spawningPosition = new Vector3(xPos, transform.position.y, transform.position.z);
                GameObject instantiatedCube = Instantiate(cube, spawningPosition, Quaternion.identity);
                cubeList.Add(instantiatedCube.transform);
                SaveSpawningData();
            }
        }
        else
        {
            while (isRowSpawningActive)
            {
                int spawnChance = Random.Range(0, 100);
                if (spawnChance + extraSpawnChance >= 60 || mustSpawn)
                {
                    Vector3 spawningPosition = new Vector3(transform.position.x, transform.position.y + extraHeight, transform.position.z);
                    GameObject instantiatedCube = Instantiate(enemyRow, spawningPosition, Quaternion.identity);
                    cubeList.Add(instantiatedCube.transform);
                    extraSpawnChance -= 15;
                    extraHeight++;
                    mustSpawn = false;
                    Debug.Log("SPAWNED ENEMY with Height = " + extraHeight);
                }
                else
                    isRowSpawningActive = false;
            }
            SaveSpawningData();
        }
    }

    public List<Transform> SaveSpawningData()
    {
        return cubeList;
    }

}
