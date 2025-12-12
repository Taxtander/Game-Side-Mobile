using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerHealthManager playerHealthManager;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerHealthManager = GetComponent<PlayerHealthManager>();
    }

    public bool IsJumping
    {
        get => playerMovement.IsJumping;
        set => playerMovement.IsJumping = value;
    }
    


    public bool IsGrounded
    {
        get => playerMovement.IsGrounded;
        set => playerMovement.IsGrounded = value;
    }

    public bool IsWall
    {
        get => playerMovement.IsWall;
        set => playerMovement.IsWall = value;
    }

    public bool IsWallJumping
    {
        get => playerMovement.IsWallJumping;
        set => playerMovement.IsWallJumping = value;
    }

    public bool IsDead
    {
        get => playerHealthManager.IsDead;
        set => playerHealthManager.IsDead = value;
    }

    public bool IsHit
    {
        get => playerHealthManager.IsHit;
        set => playerHealthManager.IsHit = value;
    }

    public int Health
    {
        get => playerHealthManager.Health;
        set => playerHealthManager.Health = value;
    }
    
    public int RemainingJumps
    {
        get => playerMovement.RemainingJumps;
        set => playerMovement.RemainingJumps = value;
    }
    
    public int MaxJumpCount
    {
        get => playerMovement.MaxJumpCount;
        set => playerMovement.MaxJumpCount = value;
    }
}