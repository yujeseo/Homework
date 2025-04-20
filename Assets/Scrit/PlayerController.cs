using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isInvincibility = false;

    public GameObject wall;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        if (moveInput > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }







    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Respawn":
                if (!isInvincibility)
                {

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            case "Finish":
                collision.GetComponent<LevelObject>().MoveToNextLevel();
                break;
            case "Enemy":
                if (isInvincibility)
                {
                    Debug.Log("Àû ¹«½Ã");
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break; 

            case "sheild":
                isInvincibility = true;
                Destroy(collision.gameObject);
                break;

            case "speed":
                moveSpeed = 6f;
                Destroy(collision.gameObject);
                break;

            case "Jump":
                jumpForce = 6f;
                Destroy(collision.gameObject);
                break;

            case "UmSheild":
                isInvincibility = false;
                Destroy(collision.gameObject);
                break;
            case "open wall":
                Destroy(wall);
                Destroy(collision.gameObject);
                break;


        }







    }






}
