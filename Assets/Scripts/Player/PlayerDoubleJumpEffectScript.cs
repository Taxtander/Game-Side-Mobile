using UnityEngine;

public class PlayerDoubleJumpEffectScript : MonoBehaviour
{
    [Header("Effect Settings")]
    [SerializeField] private GameObject effectPrefab;
    [SerializeField] private float effectLifetime = 1.5f;

    private PlayerMovement playerMovement;
    private bool isGrounded;
    private bool isWall;
    private int maxEffectPlay = 2;
    private int remainingEffectPlay = 2;

    
    private int remainingJumps;


    void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        maxEffectPlay = playerMovement.MaxJumpCount;
        remainingEffectPlay = maxEffectPlay;
    }

    void Update()
    {
        remainingJumps = playerMovement.RemainingJumps;
        isGrounded = playerMovement.IsGrounded;
        isWall = playerMovement.IsWall;

        if (isGrounded)
        {
            remainingEffectPlay = 1;
        }
        else if ((remainingJumps >= 0 && Input.GetKeyDown(KeyCode.Space) && remainingEffectPlay > 0) || (isWall && Input.GetKeyDown(KeyCode.Space)))
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, effectLifetime);
            remainingEffectPlay--;
        }
    }
}
