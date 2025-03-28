using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveDistance = 5f;
    
    private Vector3 startPosition;
    private bool movingRight = true;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate movement direction
        float direction = movingRight ? 1f : -1f;
        
        // Move the enemy
        transform.Translate(Vector3.right * direction * moveSpeed * Time.deltaTime);
        
        // Check if we need to change direction
        if (movingRight && transform.position.x >= startPosition.x + moveDistance)
        {
            movingRight = false;
        }
        else if (!movingRight && transform.position.x <= startPosition.x)
        {
            movingRight = true;
        }
    }

    public void freeze(){
        moveSpeed = 0;
    }

    public void unfreeze(){
        moveSpeed = 2;
    }
}
