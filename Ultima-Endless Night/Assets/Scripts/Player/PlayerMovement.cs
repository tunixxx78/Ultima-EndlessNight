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
    [SerializeField] Animator toniAnimator;

    private void Start()
    {
        FindObjectOfType<CollectiblesSpawmer>().SpawnNewCollectible();
        ScoringSystem.theScore = 0;
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
        float x = Input.GetAxis("Horizontal");

        rbPlayer.MovePosition(transform.position + (direction * speed * Time.deltaTime));

        toniAnimator.SetBool("Run", x != 0);
        Vector3 CharacterScale = transform.localScale;

        if(x > 0)
        {
            CharacterScale.x = -1f;
        }
        if(x < 0)
        {
            CharacterScale.x = 1f;
        }

        transform.localScale = CharacterScale;
    }

    public void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rbPlayer.AddForce(Vector3.up * jump);
            isGrounded = false;
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            player.SetActive(false);
            FindObjectOfType<ScoringSystem>().ShowGameOverStuff();
        }
        if (collision.collider.CompareTag("Collectible"))
        {
            FindObjectOfType<CollectiblesSpawmer>().SpawnNewCollectible();
            ScoringSystem.theScore += 1;
        }
        if (collision.collider.CompareTag("Collectible"))
        {
            FindObjectOfType<DestroyCollectible>().DestroyMe();
            FindObjectOfType<EnemyAi>().AddSpeed();
            //FindObjectOfType<CollectiblesSpawnPoint>().DestroyMeToo();
        }
    }
}
