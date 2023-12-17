using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool doubleJump;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpforce = 14f;
    [SerializeField] private LayerMask jumpableGround;


    private enum MovementState { idle, running, jumping, falling }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;

        }


        if (Input.GetButtonDown("Jump"))
        {

            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                doubleJump = !doubleJump;
            }
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position, sprite.flipX ? -Vector2.right : Vector2.right , 1f, jumpableGround);
        if (hit.collider != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Min(rb.velocity.y, 0f));
        }

        UpdateAnimationState();

    }
    public void UpdateAnimationState()
    {
        MovementState state;

        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;

        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;

        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        float castDistance = Mathf.Abs(rb.velocity.y) * Time.fixedDeltaTime + 0.1f;
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, castDistance, jumpableGround);
    }
}