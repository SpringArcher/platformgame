using UnityEngine;

public class TrackingEnemy : MonoBehaviour
{
    public GameObject player;
    public LayerMask groundLayerMask;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    bool playerPresent;
    float playerXPos;
    float enemyXPos;
    float dir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerXPos = player.transform.position.x;
        enemyXPos = transform.position.x;
        if (playerXPos > enemyXPos)
        {
            sr.flipX = false;
            playerPresent = RayCollisionCheck(0f, 0.45f, Vector2.right);
            if (playerPresent == true)
            {
                dir = 4;
            }
            else
            {
                dir = 0;
            }
        }
        if (playerXPos < enemyXPos)
        {
            sr.flipX = true;
            playerPresent = RayCollisionCheck(0f, 0.45f, Vector2.left);
            if (playerPresent == true)
            {
                dir = -4;
            }
            else
            {
                dir = 0;
            }
        }
        rb.linearVelocityX = dir;

        if (rb.linearVelocityX != 0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }
    public bool RayCollisionCheck(float xoffs, float yoffs, Vector2 direction)
    {
        float rayLength = 8.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward starting at the sprite's position
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, direction, rayLength, groundLayerMask);

        Color hitColor = Color.red;


        if (hit.collider != null)
        {
            print("Tracking Enemy has sensed the player!");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray's position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, direction * rayLength, hitColor);
        return hitSomething;
    }
}

