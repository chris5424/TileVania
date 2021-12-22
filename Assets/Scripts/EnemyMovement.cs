using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    BoxCollider2D myFlipCollider;
    [SerializeField] float moveSpeed = 1f;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myFlipCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        myRigidBody.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        FlipEnemyFacing();
        moveSpeed = -moveSpeed;
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-Mathf.Sign(transform.localScale.x), 1f) ;
    }
}
