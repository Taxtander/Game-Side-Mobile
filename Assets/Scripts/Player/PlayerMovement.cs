using System.Collections;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public bool IsJumping
    {
        get => isJumping;
        set => isJumping = value;
    }

    public bool IsGrounded
    {
        get => isGrounded;
        set => isGrounded = value;
    }

    public bool IsWall
    {
        get => isWall;
        set => isWall = value;
    }

    public bool IsWallJumping
    {
        get => isWallJumping;
        set => isWallJumping = value;
    }
    
    public int RemainingJumps
    {
        get => remainingJumps;
        set => remainingJumps = value;
    }

    private Rigidbody2D rb;
    private Animator anim;
    private PlayerHealthManager healthManager;

    [Header("Movement")]
    [SerializeField] private float Speed = 6f;
    [SerializeField] private float Jump = 12f;
    [SerializeField] private int maxJumpCount = 2;
    [SerializeField] private int remainingJumps;

    [Header("Collision")]
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private float WallCheckDistance;
    [SerializeField] private LayerMask LayerGround;
    
    [Header("Jump Settings")]
    [SerializeField] private float coyoteTime = 0.15f;
    [SerializeField] private float jumpBufferTime = 0.2f;

    private bool isJumping;
    private bool isGrounded;
    private bool isWall;
    private bool isWallJumping;
    
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    private float xInput;
    private bool faceRight = true;
    private float faceDir = 1;
    
    private bool isHit;
    private bool DontHit;

    private float xScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        healthManager = GetComponent<PlayerHealthManager>();

        xScale = transform.localScale.x;
        
        remainingJumps = maxJumpCount;
    }



    void Update()
    {
        isJumping = false;
        
        isHit = healthManager.GetIsHit();
        DontHit = healthManager.GetDontHit();

        xInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        rb.linearDamping = isWall ? 8 : 0;

        if (isHit)
            return;

        HandleCollision();
        HandleMovement();
        HandleFlip();
        HandleJump();
        HandleAnimation();
    }
    

    private void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down,
            GroundCheckDistance, LayerGround);

        isWall = Physics2D.Raycast(transform.position, Vector2.right * faceDir,
            WallCheckDistance, LayerGround);

        if (isGrounded && !isJumping)
        {
            coyoteTimeCounter = coyoteTime;
            remainingJumps = maxJumpCount;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

    private void HandleJump()
    {
        if (!isGrounded && isWall && Input.GetKeyDown(KeyCode.Space))
        {
            if (faceRight)
            {
                faceRight = false;
                faceDir = -1;
                transform.localScale = new Vector2(-xScale, transform.localScale.y);
                rb.linearVelocity = new Vector2(-6f, Jump);
            }
            else if (!faceRight)
            {
                faceRight = true;
                faceDir = 1;
                transform.localScale = new Vector2(xScale, transform.localScale.y);
                rb.linearVelocity = new Vector2(6f, Jump);
            }

            StopAllCoroutines();
            GetComponent<SpriteRenderer>().enabled = true;
            DontHit = false;
            StartCoroutine(WallJumping());

            remainingJumps = 0;
            jumpBufferCounter = 0;
            return;
        }
        
        if (jumpBufferCounter > 0 && (coyoteTimeCounter > 0 || remainingJumps > 0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Jump);
            isJumping = true;

            remainingJumps--;

            jumpBufferCounter = 0;
            anim.SetInteger("remainingJumps", remainingJumps);
        }
    }

    public int MaxJumpCount
    {
        get => maxJumpCount;
        set => maxJumpCount = value;
    }

    private IEnumerator WallJumping()
    {
        isWallJumping = true;
        yield return new WaitForSeconds(0.7f);
        isWallJumping = false;

    }

    private void HandleAnimation()
    {
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isWall", isWall);
        anim.SetFloat("xVelacity", rb.linearVelocity.x);
        anim.SetFloat("yVelacity", rb.linearVelocity.y);
    }

    private void HandleFlip()
    {
        if (isWallJumping)
            return;
        if (xInput == -1)
        {
            faceRight = false;
            faceDir = -1;

            transform.localScale = new Vector3(-xScale, transform.localScale.y,
                transform.localScale.z);

        }
        else if (xInput == 1)
        {
            faceRight = true;
            faceDir = 1;

            transform.localScale = new Vector3(xScale, transform.localScale.y,
                transform.localScale.z);
        }
    }

    private void HandleMovement()
    {
        if (isWall)
            return;
        if (isWallJumping)
            return;
        if (isHit)
            return;

        rb.linearVelocity = new Vector2(xInput * Speed, rb.linearVelocity.y);
    }

    public bool GetIsWallJumping()
    {
        return isWallJumping;
    }
    

    public bool GetFacingRight()
    {
        return faceRight;
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x,
            transform.position.y - GroundCheckDistance));

        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x
            + (WallCheckDistance * faceDir), transform.position.y));
    }
}
