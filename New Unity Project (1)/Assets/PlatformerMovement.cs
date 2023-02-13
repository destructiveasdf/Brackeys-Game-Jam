using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontal, jump;
    public float speed = 8f;
    public float jumpingPower = 16f;
    public bool isFacingRight = true;
    public int numberofjumps;
    public PhysicMaterial nofric;
    public Sprite thing, notherthing, smash;
    public bool canDash, isDashing;
    public float dashInterval, dashDistance, dashTime;
    public bool CanDoubleJump, unlockedDoubleJump;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GroundCheck GroundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GroundCheck = GetComponentInChildren<GroundCheck>();
        notherthing = GetComponent<SpriteRenderer>().sprite;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDashing == true)
        {
            rb.velocity = Vector2.zero;
        }
    }
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        horizontal = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");

        if(horizontal != 0)
        {
            GetComponent<SpriteRenderer>().sprite = thing;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = notherthing;

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (GroundCheck.isgrounded == true)
            {
                Jump(jumpingPower);
            }
            else
            {
                if (unlockedDoubleJump)
                {
                    if (CanDoubleJump)
                    {
                        Jump(jumpingPower);
                        CanDoubleJump = false;
                    }
                }
            }

        }

        if(GroundCheck.isgrounded == false && GroundCheck.issmash == false)
        {
            GetComponent<SpriteRenderer>().sprite = thing;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(canDash == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(Dash());
            }
        }
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
    public void Jump(float jumppower)
    {
        rb.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        gameObject.layer = 8;
        Vector3 thing = new Vector3(1, 1, 1);
        if (transform.localScale == thing)
        {
            rb.velocity = transform.right * dashDistance;
        }
        else
        {
            rb.velocity = -transform.right * dashDistance;

        }
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        gameObject.layer = 0;
        yield return new WaitForSeconds(dashInterval);
        
        canDash = true;
    }
}
