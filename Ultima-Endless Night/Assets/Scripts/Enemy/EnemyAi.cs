using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform player;
    [SerializeField] private float enemySpeed = 3, enemyAngularSpeed = 180, enemyAcceleration = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().speed = enemySpeed;
        GetComponent<NavMeshAgent>().angularSpeed = enemyAngularSpeed;
        GetComponent<NavMeshAgent>().acceleration = enemyAcceleration;
        enemy.SetDestination(player.position);

        
    }

    public void AddSpeed()
    {
        enemySpeed += 1;
        enemyAngularSpeed += 10;
        enemyAcceleration += 1;
    }
}
