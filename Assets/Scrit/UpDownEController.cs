using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownEController : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private bool isMovingUP = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isMovingUP)
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        else
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
            isMovingUP = !isMovingUP;
    }
}
