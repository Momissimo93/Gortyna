using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    Command moveLeft;
    Command moveRight;

    bool facingRight = false;

    void Start()
    {
        moveLeft = new MoveLeft();
        moveRight = new MoveRight();
        animator.SetFloat("Speed", speed);
    }

    public void MoveLeft()
    {
        moveLeft.Execute(trans, -1);
    }

    public void MoveRight()
    {
        moveRight.Execute(trans, 1);
    }

    public void SetRotation(int s)
    {
        if (s == 1)
        {
            if (!facingRight)
            {
                transform.Rotate(0, 180f, 0f);
                facingRight = true;
                direction = -1;
            }
        }
        else if (s == -1)
        {
            if (facingRight)
            {
                transform.Rotate(0f, 180f, 0f);
                facingRight = false;
                direction = 1;
            }
        }
    }
}
