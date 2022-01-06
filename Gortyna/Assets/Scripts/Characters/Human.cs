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
    public float dashPower;
    public float dashTime;

    [HideInInspector] public bool isOnGround;
    [HideInInspector] public bool isHit;
    //[HideInInspector] public bool isJumping;
    [HideInInspector] public bool isDashing = false;
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool isOnPlatform = false;
    [HideInInspector] public bool canMutate_Bunny;
    [HideInInspector] public bool canMutate_Bird;
    [HideInInspector] public BoxCollider2D boxC2D;

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
        if(canMove)
        {
            if (leftFoot.IsOnGround() == true || rightFoot.IsOnGround() == true && canMove)
            {
                isOnGround = true;
                animator.SetBool("isJumping", false);

            }
            else if (leftFoot.IsOnGround() == false || rightFoot.IsOnGround() == false && canMove)
            {
                isOnGround = false;
                animator.SetBool("isJumping", true);
            }
        }
        //When we get hit we want to stop the jumping animation. Also we set the bool variable isOnGround to be false so that we can use it to tell wheter or not we are jumping on the enemey
        else if (!canMove)
        {
            isOnGround = false;
            animator.SetBool("isJumping", false);
            Debug.Log("I have been hit");
        }
    }
}

