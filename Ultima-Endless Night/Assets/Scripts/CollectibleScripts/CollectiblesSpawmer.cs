using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesSpawmer : MonoBehaviour
{
    [SerializeField] GameObject[] collectiblesSpawnPoints;

    public void SpawnNewCollectible()
    {
        int rand = Random.Range(0, collectiblesSpawnPoints.Length);

        Instantiate(collectiblesSpawnPoints[rand], transform.position, Quaternion.identity);
    }
}
