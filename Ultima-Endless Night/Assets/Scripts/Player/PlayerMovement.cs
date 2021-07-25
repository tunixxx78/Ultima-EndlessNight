using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f, jump = 10f;
    [SerializeField] private GameObject player;
    [SerializeField] Rigidbody rbPlayer;
    private Vector3 movement;
    private bool isGrounded;

    private void Start()
    {
        FindObjectOfType<CollectiblesSpawmer>().SpawnNewCollectible(); 
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        PlayerJump();

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    private void FixedUpdate()
    {
        MovePlayer(movement);
    }

    public void MovePlayer(Vector3 direction) 
    {
        rbPlayer.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    public void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rbPlayer.AddForce(Vector3.up * jump);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            player.SetActive(false);
        }
        if (collision.collider.CompareTag("Collectible"))
        {
            FindObjectOfType<CollectiblesSpawmer>().SpawnNewCollectible();
        }
        if (collision.collider.CompareTag("Collectible"))
        {
            FindObjectOfType<DestroyCollectible>().DestroyMe();
            FindObjectOfType<EnemyAi>().AddSpeed();
            //FindObjectOfType<CollectiblesSpawnPoint>().DestroyMeToo();
        }
    }
}
