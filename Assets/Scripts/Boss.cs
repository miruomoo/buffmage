using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Shooting Settings")]
    public float shootingRange = 10f; // Range at which the boss will start shooting
    public float magicSpeed = 10f; // Speed of the magic projectile
    public float shootCooldown = 2f; // Time between shots
    public GameObject magicPrefab; // Prefab of the magic projectile to shoot
    public Transform firePoint; // Point from which magic projectiles will spawn

    private float lastShotTime; // Time when the last shot was fired
    private GameObject player; // Reference to the player

    [Header("Health Settings")]
    public int health = 5;
    [SerializeField] private GameObject frozenEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastShotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            return;
        }

        // Check if player is in range and enough time has passed since last shot
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= shootingRange && Time.time >= lastShotTime + shootCooldown)
        {
            ShootMagic();
            lastShotTime = Time.time;
        }
    }

    void ShootMagic()
    {
        // Calculate direction from boss to player
        Vector3 direction = (player.transform.position - transform.position).normalized;
        
        // Create the magic projectile
        GameObject magic = Instantiate(magicPrefab, 
            firePoint != null ? firePoint.position : transform.position, 
            Quaternion.identity);
        
        // Add velocity to the magic projectile
        Rigidbody2D rb = magic.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * magicSpeed;
        }
        
        // Rotate magic projectile to face direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        magic.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private IEnumerator UnfreezeAfterDelay(SlimeMove slime, float delay)
    {
        yield return new WaitForSeconds(delay);
        slime.unfreeze();
    }

    private IEnumerator DeactivateFrozenEffect(GameObject frozenEffect, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (frozenEffect != null)
        {
            frozenEffect.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            health--;
            other.gameObject.SetActive(false);
            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("Iceball"))
        {
            // Check if THIS enemy has SlimeMove component
            SlimeMove slimeMove = GetComponent<SlimeMove>();
            if (slimeMove != null)
            {
                slimeMove.freeze();
                StartCoroutine(UnfreezeAfterDelay(slimeMove, 6f));
                
                // Simply activate/deactivate the referenced effect
                if (frozenEffect != null)
                {
                    frozenEffect.SetActive(true);
                    StartCoroutine(DeactivateFrozenEffect(frozenEffect, 6f));
                }
            }
            other.gameObject.SetActive(false);
        }
    }
}
