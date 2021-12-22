using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    ConstantForce2D myConstantForce2D;
    [SerializeField] float bulletSpeed = 1f;
    [SerializeField] float rotationTorque = 10f;
    PlayerMovement playerMovement;
    float xSpeed;
    float endRotationTorque;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myConstantForce2D = GetComponent<ConstantForce2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        xSpeed = playerMovement.transform.localScale.x * bulletSpeed;
        endRotationTorque = -playerMovement.transform.localScale.x * rotationTorque;
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(xSpeed, 0f);
        myConstantForce2D.torque = endRotationTorque;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
