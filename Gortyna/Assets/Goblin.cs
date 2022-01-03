using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Character
{
    AIPlayerDetector_CircleCast playerDetector_CircleCast;
    MoveTowardsTarget moveTowardsTarget;
    Patrolling patrolling;
    private Eye eye;
    private RightFoot foot;

    // Start is called before the first frame update
    void Start()
    {
        playerDetector_CircleCast = gameObject.GetComponent<AIPlayerDetector_CircleCast>();
        moveTowardsTarget = gameObject.GetComponent<MoveTowardsTarget>();
        patrolling = gameObject.GetComponent<Patrolling>();
        eye = gameObject.GetComponent<Eye>();
        direction = 1;

        foot = gameObject.GetComponent<RightFoot>();

        if (gameObject.GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foot.EmittingRay();
        foot.DrawRaysFromFeet();
        eye.EmittingRay(direction);
        eye.DrawRaysFromFeet(direction);
        GroundCheck();

            if (playerDetector_CircleCast.playerDetected)
            {
                moveTowardsTarget.Move(speed, playerDetector_CircleCast.Target.transform);
            }
            else if (playerDetector_CircleCast.playerDetected == false)
            {
                speed = 1;
                patrolling.Move(speed, foot, direction);
            }
    }
    void GroundCheck()
    {
        if (playerDetector_CircleCast.playerDetected == false)
        {
            if (!foot.rightFootRays)
            {
                transform.Rotate(0f, 180f, 0f);
                direction = direction * -1;
            }
            else if (eye.eyeRay)
            {
                transform.Rotate(0f, 180f, 0f);
                direction = direction * -1;
            }
        }
        else if (playerDetector_CircleCast.playerDetected == true)
        {
            if (!foot.rightFootRays)
            {
                speed = 0;
                canMove = false;
            }
            else if (eye.eyeRay)
            {
                speed = 0;
                canMove = false;
            }
        }
    }
}
