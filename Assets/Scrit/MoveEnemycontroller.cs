using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemycontroller : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    private float traceDistance = 20f;
    private float MoveTime = 9999;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float xDistance = player.position.x - transform.position.x;

        if (Mathf.Abs(xDistance) < traceDistance)
        {
            MoveTime += Time.deltaTime;
            if (MoveTime >= 0.3f)
            {
                MoveTime = 0;
                xDistance = Mathf.Sign(xDistance);
                rb.velocity = new Vector2(xDistance * moveSpeed, rb.velocity.y + moveSpeed);
                rb.AddForce(new Vector2(xDistance * moveSpeed, moveSpeed / 12), ForceMode2D.Impulse);
            }
        }
    }
}
