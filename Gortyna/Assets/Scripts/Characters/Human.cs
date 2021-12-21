using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Human : Character
{
    protected bool facingRight;
    public bool canMove;

    public int jumpForce;
    public LeftFoot leftFoot;
    public RightFoot rightFoot;
    public bool isOnGround;
    public bool isJumping;

    //public float baseSpeed;
    public float dashPower;
    public float dashTime;

    public bool isDashing = false;
    public bool isMoving = false;
    public bool isOnPlatform = false;
    public bool canMutate_Bunny;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int enemyLayer = 1 << 8;

    public BoxCollider2D boxC2D;

    //public UnityEvent OnLandEvent;

    //public Vector3 originalVelocity;
   /* private int platform = 1 << 9;
    Vector2 center;
    RaycastHit2D centerRay;*/

    void Start()
    {
        //speed = baseSpeed;

        SetDirection();

        canMutate_Bunny = false;

        boxC2D = boxCollider2D;

        //originalVelocity = rigidBody.velocity;

    }

    void Update()
    {
        leftFoot.EmittingRay();
        leftFoot.DrawRaysFromFeet();

        rightFoot.EmittingRay();
        rightFoot.DrawRaysFromFeet();

        //center = new Vector2(boxCollider2D.bounds.min.x, boxCollider2D.bounds.min.y);
        //centerRay = Physics2D.Raycast(center, Vector2.down, 0.5f, platform);

        /*if (centerRay)
        {
            Debug.Log("We are on the platform");
            isNotOnPlatform = false;
        }*/
    }

    private void FixedUpdate()
    {
        IsOnGround();
    }

    private void SetDirection()
    {
        float localEu = trans.localEulerAngles.y;

        if (localEu == 180.0f)
        {
            direction = -1;
            facingRight = false;
        }
        else if(localEu == 0.0f)
        {
            direction = 1;
            facingRight = true;
        }
        else
        {
            Debug.Log("....");
        }
    }

    public void SetRotation(string s)
    {
        if (s == "right")
        {
            if (!facingRight)
            {
                transform.Rotate(0, 180f, 0f);
                facingRight = true;
                direction = 1;
            }
        }
        else if (s == "left")
        {
            if (facingRight)
            {
                transform.Rotate(0f, 180f, 0f);
                facingRight = false;
                direction = -1;
            }
        }
    }
    public void IsOnGround()
    {
        if (leftFoot.IsOnGround() == true || rightFoot.IsOnGround() == true)
        {
            isOnGround = true;
            //Debug.Log("I  on ground");
        }
        else if (leftFoot.IsOnGround() == false || rightFoot.IsOnGround() == false)
        {
            isOnGround = false;
            //Debug.Log("I NOT  on ground");
        }
    }
}

