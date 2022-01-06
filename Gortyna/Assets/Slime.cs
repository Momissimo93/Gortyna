using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public Eye eye;
    public SlimeAttack attack;

    void Update()
    {
        eye.EmittingRay(direction);
        eye.DrawRaysFromFeet(direction);
        GroundCheck();
        attack.CheckHero();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            HorizontalMovement();
        }
    }
    void GroundCheck()
    {
        if (eye.eyeRay)
        {
            transform.Rotate(0f, 180f, 0f);
            direction = direction * -1;
        }
    }
    void HorizontalMovement()
    {
        if (direction == -1)
        {
            MoveLeft();
        }
        else
            MoveRight();
    }
}
