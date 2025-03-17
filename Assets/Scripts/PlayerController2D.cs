using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

    public Transform groundCheck;  // Empty GameObject under the player
    public LayerMask groundLayer;  // Layer to detect ground

    public float fallThreshold = -15f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Move the player
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

       
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        
        if (transform.position.y < fallThreshold)
        {
            RestartScene();
        }
    }

    private bool IsGrounded()
    {
        // Check if player is touching the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
