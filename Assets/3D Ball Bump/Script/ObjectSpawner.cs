using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] TringlePrefabs;
    private Vector3 spawnObstaclePositin;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePositin);
        if (distanceToHorizon < 120)
        {
            SpawnTriangle();
        }
    }

    void SpawnTriangle()
    {
        spawnObstaclePositin = new Vector3(0, 0, spawnObstaclePositin.z + 30);
        Instantiate(TringlePrefabs[(Random.Range(0,TringlePrefabs.Length))], spawnObstaclePositin, Quaternion.identity);
    }
}
