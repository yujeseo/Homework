using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private bool isMovingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isMovingRight)
            rb.velocity = new Vector2(moveSpeed, rb.velocity.x);
        else
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
            isMovingRight = !isMovingRight;
    }
}
