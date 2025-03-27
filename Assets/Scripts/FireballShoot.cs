using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab; // Fireball prefab
    [SerializeField] private float fireballSpeed = 10f; // Speed of the fireball
    [SerializeField] private Transform firePoint; // Optional: Point where fireball spawns

    private bool hasFireballPower = false; // Track if power is active

    // Public method to enable fireball power
    public void EnableFireballPower()
    {
        hasFireballPower = true;
    }

    // Public method to disable fireball power
    public void DisableFireballPower()
    {
        hasFireballPower = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Only shoot if we have the power and click
        if (hasFireballPower && Input.GetMouseButtonDown(0))
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        // Get mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Set z to 0 if in 2D

        // Calculate direction from current position to mouse position
        Vector3 direction = (mousePos - transform.position).normalized;

        // Create the fireball
        GameObject fireball = Instantiate(fireballPrefab, 
            firePoint != null ? firePoint.position : transform.position, 
            Quaternion.identity);

        // Add velocity to the fireball
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * fireballSpeed;
        }

        // Optional: Rotate fireball to face direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        fireball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
