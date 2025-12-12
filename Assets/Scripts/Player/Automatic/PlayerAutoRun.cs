using System.Collections;
using UnityEngine;

public class PlayerAutoRun : MonoBehaviour
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

    private bool faceRight = true;
    private float faceDir = 1;

    private float xScale;

    public float XScale
    {
        get => xScale;
        set => xScale = value;
    }

    public bool FaceRight
    {
        get => faceRight;
        set => faceRight = value;
    }

    public float Speed1
    {
        get => Speed;
        set => Speed = value;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xScale = transform.localScale.x;
    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(faceDir * Speed, rb.linearVelocity.y);

        HandleFlip();
        HandleCollision();
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
            transform.localScale = new Vector2(xScale, transform.localScale.y);
        }
        else
        {
            faceDir = -1;
            transform.localScale = new Vector2(-xScale, transform.localScale.y);
        }
    }




}