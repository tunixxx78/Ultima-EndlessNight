using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] Rigidbody rbPlayer;
    private Vector3 movement;

    private void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        MovePlayer(movement);
    }

    public void MovePlayer(Vector3 direction) 
    {
        rbPlayer.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
