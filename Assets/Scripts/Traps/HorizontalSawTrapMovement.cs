using UnityEngine;

public class HorizontalSawTrapMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] private float Speed;

    [Header("Collision")]
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private float WallCheckDistance;
    [SerializeField] private Transform CheckNoGroundTransform;
    [SerializeField] private LayerMask LayerGround;

    private bool isGrounded;
    private bool CheckNoGround;
    private bool isWall;

    private bool faceRight = false;
    private float faceDir = -1;

    private float xScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xScale = transform.localScale.x;
    }

    private void Update()
    {
        HandleCollision();
        HandleFlip();
        
        rb.linearVelocity = new Vector2(faceDir * Speed, rb.linearVelocity.y);
    }

    private void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down,
            GroundCheckDistance, LayerGround);

        CheckNoGround = Physics2D.Raycast(CheckNoGroundTransform.position,
            Vector2.down, GroundCheckDistance, LayerGround);

        isWall = Physics2D.Raycast(transform.position, Vector2.right * faceDir,
            WallCheckDistance, LayerGround);
    }

    private void HandleFlip()
    {
        if (isGrounded)
        {
            if (isWall || !CheckNoGround)
            {
                faceRight = !faceRight;
            }
        }

        if (faceRight)
        {
            faceDir = 1;
            transform.localScale = new Vector2(-xScale, transform.localScale.y);
        }
        else
        {
            faceDir = -1;
            transform.localScale = new Vector2(xScale, transform.localScale.y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x,
            transform.position.y - GroundCheckDistance));

        Gizmos.DrawLine(CheckNoGroundTransform.position,
            new Vector2(CheckNoGroundTransform.position.x,
            CheckNoGroundTransform.position.y - GroundCheckDistance));

        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x +
            (faceDir * WallCheckDistance), transform.position.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealthManager playerHealth = other.gameObject.GetComponent<PlayerHealthManager>();
        
        if (other.CompareTag("Player"))
            
            playerHealth.Hit();
            
    }
}
