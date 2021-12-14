using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HumanForm : Character
{
    protected bool facingForward = true;

    public int jumpForce;
    public LeftFoot leftFoot;
    public RightFoot rightFoot;
    public bool isOnGround;
    public bool isJumping;

    public float baseSpeed;
    public float dashPower;
    public float dashTime;

    public bool isDashing = false;
    public bool isMoving = false;

    public bool canMutate_Bunny = false;

    public UnityEvent OnLandEvent;

    void Start()
    {
       speed = baseSpeed;
       if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    void Update()
    {
        leftFoot.EmittingRay();
        leftFoot.DrawRaysFromFeet();

        rightFoot.EmittingRay();
        rightFoot.DrawRaysFromFeet();

        //IsOnGround();
    }

    private void FixedUpdate()
    {
        IsOnGround();
    }

    public void SetRotation(string s)
    {
        if (s == "right")
        {
            if (!facingForward)
            {
                transform.Rotate(0, 180f, 0f);
                facingForward = true;
            }
        }
        else if (s == "left")
        {
            if (facingForward)
            {
                transform.Rotate(0f, 180f, 0f);
                facingForward = false;
            }
        }
    }
    public void IsOnGround()
    {
        if (leftFoot.IsOnGround() == true || rightFoot.IsOnGround() == true)
        {
            isOnGround = true;
            Debug.Log("The player is on the ground");
            //OnLandEvent.Invoke();
        }
        else if (leftFoot.IsOnGround() == false || rightFoot.IsOnGround() == false)
        {
            isOnGround = false;
            Debug.Log("The player is NOT the ground");
            //animator.SetTrigger("IsJumping");
        }
    }

    public IEnumerator Dash()
    {
        isDashing = true;
        speed *= dashPower;
        yield return new WaitForSeconds(dashTime);
        speed = baseSpeed;
        isDashing = false;
    }

    public void OnLanding()
    {
        Debug.Log("I have landed");
        animator.SetBool("IsJumping", false);
    }
}
