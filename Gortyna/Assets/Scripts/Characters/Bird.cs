using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Character
{
    public float flyingPower;
    public LeftFoot leftFoot;
    public RightFoot rightFoot;
    public bool isOnGround;

    void Update()
    {
        leftFoot.EmittingRay();
        leftFoot.DrawRaysFromFeet();

        rightFoot.EmittingRay();
        rightFoot.DrawRaysFromFeet();
    }

    private void FixedUpdate()
    {
        if(leftFoot && rightFoot)
        {
            IsOnGround();
        }
    }

    public void SetTransform(Transform tr)
    {
        trans = tr;
    }
    public void SetDirection(float dr)
    {
        direction = dr;
    }
    public void SetRotation(string s)
    {
        if (s == "right")
        {
            if (direction == -1)
            {
                transform.Rotate(0f, 180f, 0f);
                direction = 1;
            }
        }
        else if (s == "left")
        {
            if (direction == 1)
            {
                transform.Rotate(0f, 180f, 0f);
                direction = -1;
            }
        }
    }

    public void SetLifePoint(int lp)
    {
        this.currentLifePoints = lp;
    }

    public void IsOnGround()
    {
        if (leftFoot.IsOnGround() == true || rightFoot.IsOnGround() == true)
        {
            isOnGround = true;
            Debug.Log("I  on ground");
            animator.SetBool("Bird_Flying", false);
        }
        else if (leftFoot.IsOnGround() == false || rightFoot.IsOnGround() == false)
        {
            isOnGround = false;
            Debug.Log("I NOT  on ground");
            animator.SetBool("Bird_Flying", true);
        }
    }
}
