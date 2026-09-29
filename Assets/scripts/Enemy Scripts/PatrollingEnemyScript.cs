using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    public GameObject player;
    public LayerMask groundLayerMask;
    bool result;
    bool isGroundedLeft = true;
    bool isGroundedRight = false;
    float dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        groundLayerMask = LayerMask.GetMask("Ground");
        dir = 2;


    }

    // Update is called once per frame
    void Update()
    {
        float ex;

        if (rb.linearVelocityX != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        ex = player.transform.position.x;
        print("enemy x =" + ex);
        rb.linearVelocityX = dir;

        isGroundedLeft = RayCollisionCheck(-1f, 0);
        isGroundedRight = RayCollisionCheck(1f, 0);
        if (isGroundedLeft == false && dir < 0)
        {
            dir = 2;
        }
        if (isGroundedRight == false && dir > 0)
        {
            dir = -2;
        }
        FlipSprite();
    }
    void FlipSprite()
    {
        if (rb.linearVelocityX < 0)
        {
            sr.flipX = false;
        }
        if (rb.linearVelocityX > -0)
        {
            sr.flipX = true;
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
}
