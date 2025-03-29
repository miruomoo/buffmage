using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceballShoot : MonoBehaviour
{
    [SerializeField] private GameObject iceballPrefab; // Iceball prefab
    [SerializeField] private float iceballSpeed = 10f; // Speed of the iceball
    [SerializeField] private Transform icePoint; // Optional: Point where iceball spawns

    private bool hasFreezePower = false; // Track if power is active

    // Move these outside Update, at class level
    private float nextFireTime = 0f;
    private float fireRate = 0.5f; // Can shoot every 0.5 seconds

    // Public method to enable freeze power
    public void EnableFreezePower()
    {
        hasFreezePower = true;
    }

    // Public method to disable freeze power
    public void DisableFreezePower()
    {
        hasFreezePower = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Only shoot if we have the power, click, and enough time has passed
        if (hasFreezePower && Input.GetMouseButtonDown(1) && Time.time >= nextFireTime && gameObject.GetComponent<PlayerMana>().currentMana >= 2)
        {
            ShootIceball();
            nextFireTime = Time.time + fireRate; // Set next allowed fire time
            gameObject.GetComponent<PlayerMana>().UseSpell("freeze");
        }
    }

    void ShootIceball()
    {
        // Get mouse position in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Set z to 0 if in 2D

        // Calculate direction from current position to mouse position
        Vector3 direction = (mousePos - transform.position).normalized;

        // Create the iceball
        GameObject iceball = Instantiate(iceballPrefab, 
            icePoint != null ? icePoint.position : transform.position, 
            Quaternion.identity);

        // Add velocity to the iceball
        Rigidbody2D rb = iceball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * iceballSpeed;
        }

        // Optional: Rotate iceball to face direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        iceball.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
