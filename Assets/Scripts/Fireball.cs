using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the ground layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Optional: Add particle effects or sound here before destroying
            
            // Destroy the fireball
            Destroy(gameObject);
        }
    }
}
