using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesSpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject collectible;

    private void Start()
    {
        Instantiate(collectible, transform.position, Quaternion.identity);
    }

    public void DestroyMeToo()
    {
        Destroy(this.gameObject);
    }
}
