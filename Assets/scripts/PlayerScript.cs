using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    //declare the variables
    InputAction moveAction;
    InputAction jumpAction;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    public LayerMask groundLayerMask;
    bool result;
    bool isGroundedBottomMid;
    bool isGroundedBottomLeft;
    bool isGroundedBottomRight;
    bool isJumping;

    void Start()
    {
        //initialise the variables
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        groundLayerMask = LayerMask.GetMask("Ground");

        //required: a 2D Rigidbody component attached to the Game Object
        rb = GetComponent<Rigidbody2D>();   //initialise the rigidbody component
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();        
        isGroundedBottomMid = false;
        isGroundedBottomLeft = false;
        isGroundedBottomRight = false; 
   
    }


    // Update is called once per frame
    void Update()
    {
        /* read the x-axis and output it to the rigidbody
        float moveVelX = moveAction.ReadValue<Vector2>().x;
        // read the x-axis and output it to the rigidbody
        float moveVelY = moveAction.ReadValue<Vector2>().y;
        rb.linearVelocity = new Vector2(moveVelX*10,moveVelY*10);
        */
        Vector2 moveVel = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveVel.x * 7, rb.linearVelocity.y);

        isGroundedBottomMid = RayCollisionCheck(0, 0.2f);
        isGroundedBottomLeft = RayCollisionCheck(-0.6f, 0.2f);
        isGroundedBottomRight = RayCollisionCheck(0.6f, 0.2f);

        if (isGroundedBottomMid || isGroundedBottomLeft || isGroundedBottomRight == true)
        {
            Jump();
        }
        if (rb.linearVelocityX != 0 && isJumping == false)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        if (isJumping == true && (isGroundedBottomMid || isGroundedBottomLeft || isGroundedBottomRight == false))
        {
            anim.SetBool("jump", true);
        }
        if (isGroundedBottomMid || isGroundedBottomLeft || isGroundedBottomRight == true)
        {
            anim.SetBool("jump", false);
        }
        FlipSprite();
    }
    void Jump()
    {
    if (jumpAction.WasPressedThisFrame())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 9.5f );
            isJumping = true;

        }
        else 
        {
            isJumping = false;
        }
    }
    public bool RayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.2f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward starting at the sprite's position
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray's position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);
        return hitSomething;
    }
    void FlipSprite()
    {
        if (rb.linearVelocityX < -0.1f)
        {
            sr.flipX = true;
        }
        if (rb.linearVelocityX > 0.1f)
        {
            sr.flipX = false;
        }
    }
}