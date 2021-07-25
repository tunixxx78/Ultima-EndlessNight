using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectible : MonoBehaviour
{
    public void DestroyMe()
    {
        Destroy(gameObject);
        Debug.Log("cubeDestroyed");
    }
}
