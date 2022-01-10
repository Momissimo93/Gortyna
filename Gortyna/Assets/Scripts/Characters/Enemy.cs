using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private Command moveLeft;
    private Command moveRight;

    [HideInInspector] public bool facingRight = false;

    void Start()
    {
        //The maxLifePoints are set in the inspector. Then the currentLifePoints are equalized to be equal to the maxLifePoints
        currentLifePoints = maxLifePoints;

        //We want all the enemies apart from the GoblinBomber to have the following attributes 
        if(!gameObject.GetComponent<GoblinBomber>())
        {
            moveLeft = new MoveLeft();
            moveRight = new MoveRight();
            animator.SetFloat("Speed", speed);
        }
    }

    //Public methods used 
    protected void MoveLeft()
    {
        moveLeft.Execute(trans, -1);
    }

    protected void MoveRight()
    {
        moveRight.Execute(trans, 1);
    }

    protected void SetRotation(int s)
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
