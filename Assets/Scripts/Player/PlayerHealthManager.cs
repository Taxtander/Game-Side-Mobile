using System.Collections;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public bool IsHit
    {
        get => isHit;
        set => isHit = value;
    }

    public bool IsDead
    {
        get => isDead;
        set => isDead = value;
    }


    private Rigidbody2D rb;
    private Animator anim;
    
    [Header("Health")]
    [SerializeField] public int Health = 3;
    
    [Header("Prefab")]
    [SerializeField] private GameObject DieEffect;

    public int Health1
    {
        get => Health;
        set => Health = value;
    }

    private bool isHit;
    private bool isDead = false;
    private bool DontHit;
    
    private bool isWallJumping;
    private bool faceRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandlePlayerHealth();
    }

    private void HandlePlayerHealth()
    {
        isWallJumping = gameObject.GetComponent<PlayerMovement>().GetIsWallJumping();
        faceRight  = gameObject.GetComponent<PlayerMovement>().GetFacingRight();
        
        if (Health <= 0)
        {
            isDead = true;

            Instantiate(DieEffect, transform.position, Quaternion.identity);
            
            Destroy(gameObject);

            

            
           
        }
    }
    

    public void Hit()
    {
        if (isHit)
            return;
        if (DontHit)
            return;

        Health -= 1;
        anim.SetTrigger("isHit");

        isWallJumping = false;

        rb.linearVelocity = new Vector2(faceRight ? -4 : 4, rb.linearVelocity.y);

        StopAllCoroutines();
        StartCoroutine(Hiting());
    }   

    private IEnumerator Hiting()
    {
        isHit = true;
        yield return new WaitForSeconds(0.3f);
        isHit = false;

        StartCoroutine(HitingAnimation());
    }

    private IEnumerator HitingAnimation()
    {
        DontHit = true;

        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);

        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);

        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);

        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(0.1f);

        DontHit = false;
    }

    private IEnumerator Waite(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
    }

    public void dead()
    {
        Health = 0;
    }

    public bool GetDontHit()
    {
        return DontHit;
    }

    public bool GetIsHit()
    {
        return isHit;
    }
}
