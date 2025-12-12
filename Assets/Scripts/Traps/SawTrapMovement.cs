using System;
using UnityEngine;

public class SawTrapMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float speed = 2f;

    [Header("Collision")]
    [SerializeField] private float checkDistance = 0.5f;
    [SerializeField] private LayerMask groundLayer;

    private Vector2 direction = Vector2.right; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleCollision();
    }

    private void HandleMovement()
    {
        rb.linearVelocity = direction * speed;
    }

    private void HandleCollision()
    {
        RaycastHit2D forwardHit = Physics2D.Raycast(rb.position, direction, checkDistance, groundLayer);

        Vector2 leftDir = new Vector2(-direction.y, direction.x);
        RaycastHit2D leftHit = Physics2D.Raycast(rb.position, leftDir, checkDistance, groundLayer);

        if (forwardHit.collider != null)
        {
            direction = leftDir;
        }
        else if (leftHit.collider == null)
        {
            direction = leftDir;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealthManager playerHealth = other.gameObject.GetComponent<PlayerHealthManager>();
        
        if (other.CompareTag("Player"))
            
            playerHealth.Hit();
            
    }

    private void OnDrawGizmos()
    {
        if (rb == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(rb.position, rb.position + direction * checkDistance);

        Vector2 leftDir = new Vector2(-direction.y, direction.x);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rb.position, rb.position + leftDir * checkDistance);
    }
}