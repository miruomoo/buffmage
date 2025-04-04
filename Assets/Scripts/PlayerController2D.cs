using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount = 0;     // Track number of jumps
    public int maxJumps = 1;       // Maximum number of jumps allowed

    public Transform groundCheck;  // Empty GameObject under the player
    public LayerMask groundLayer;  // Layer to detect ground

    public float fallThreshold = -15f; 
    public GameObject deathMenuPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (deathMenuPanel == null)
        {
            deathMenuPanel = GameObject.Find("DeathMenuCanvas");  
        }
    }

    void Update()
    {
        
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Move the player
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check if grounded and reset jump count
        if (IsGrounded())
        {
            jumpCount = 0;
        }
       
        // Jump when button pressed and either grounded or have jumps remaining
        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }

        
        if (transform.position.y < fallThreshold)
        {
            ShowDeathMenu();
        }
    }

    private bool IsGrounded()
    {
        // Check if player is touching the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

     private void ShowDeathMenu()
    {
        if (deathMenuPanel != null)
        {
            deathMenuPanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
        else
        {
            Debug.LogError("DeathMenuPanel is not assigned! Make sure it's in the scene.");
        }
    }
}
