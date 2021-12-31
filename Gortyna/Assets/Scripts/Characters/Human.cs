using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Human : Character
{
    protected bool facingRight;

    public int jumpForce;
    public LeftFoot leftFoot;
    public RightFoot rightFoot;
    public bool isOnGround;
    public bool isJumping;

    public float dashPower;
    public float dashTime;


    public bool isDashing = false;
    public bool isMoving = false;
    public bool isOnPlatform = false;
    public bool canMutate_Bunny;
    public bool canMutate_Bird;


    public BoxCollider2D boxC2D;

    void Start()
    {

        SetDirection();

        canMutate_Bunny = false;

        boxC2D = boxCollider2D;

        trans = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        leftFoot.EmittingRay();
        leftFoot.DrawRaysFromFeet();

        rightFoot.EmittingRay();
        rightFoot.DrawRaysFromFeet();
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

