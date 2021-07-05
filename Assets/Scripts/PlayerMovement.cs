using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float jumpForce = 1.0f;
    public float moveSpeed = 1.0f;
    public int nbJump = 1;
    int jumpLeft;
    bool isGround = false;
    bool spaceIsPressed = false;
    // Start is called before the first frame update
    public SpriteRenderer playerSprite;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpLeft = nbJump;
    }

    // Update is called once per frame
    void Update()
    {
        //JUMP
        if(Input.GetKey(KeyCode.Space) && jumpLeft > 0 && !spaceIsPressed)
        {
            rb2d.velocity = Vector2.up * jumpForce;
            jumpLeft--;
            spaceIsPressed = true;
        }

        //MOVE LEFT OR RIGHT
        if(Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.right * (Time.deltaTime * moveSpeed);
            playerSprite.flipX = true;
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
            playerSprite.flipX = false;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            spaceIsPressed = false;
        }
        //RAYCAST TO CHECK IF PLAYER IS ON THE GROUND
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            if(distance < 0.5f && !spaceIsPressed)
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
        }

        //WHEN IS ON THE GROUND
        if(isGround)
        {
            jumpLeft = nbJump;
        }
    }
}
