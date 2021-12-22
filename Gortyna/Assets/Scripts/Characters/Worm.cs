using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm: Enemy
{
    public LeftFoot leftFoot;
    public RightFoot rightFoot;
    public WarmAttackPoint attackPoint;
    //private bool attack;

    void Update()
    {
        leftFoot.EmittingRay();
        leftFoot.DrawRaysFromFeet();

        rightFoot.EmittingRay();
        rightFoot.DrawRaysFromFeet();

        GroundCheck();

        attackPoint.CheckHero();

        //HorizontalMovement();
    }
    private void FixedUpdate()
    {
        HorizontalMovement();
    }

    void GroundCheck()
    {
        if((!leftFoot.leftFootRays) || (!rightFoot.rightFootRays))
        {
            transform.Rotate(0f, 180f, 0f);
            direction = direction * -1;
        }
    }

    void HorizontalMovement()
    {
        animator.Play("Worm_Run");
        if (direction == -1)
        {
            MoveLeft();
        }
        else
            MoveRight();
    }
}
