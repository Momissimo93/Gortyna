using UnityEngine;

public class Goblin: Enemy
{
    public AIPlayerDetector_CircleCast playerDetector_CircleCast;
    public Eye eye;
    //public MoveTowardsTarget moveTowardsTarget;
    //public Patrolling patrolling;

    // Update is called once per frame
    void Update()
    {
        eye.EmittingRay(direction);
        eye.DrawRaysFromFeet(direction);
        GroundCheck();
        PlayerCheck();

        if (playerDetector_CircleCast.playerDetected)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(playerDetector_CircleCast.Target.transform.position.x, transform.position.y, playerDetector_CircleCast.Target.transform.position.y), speed * Time.deltaTime);
            if (playerDetector_CircleCast.attack == true)
            {
                speed = 0;
            }
            else
            {
                speed = 1;
            }
        }
        else
        {
            HorizontalMovement();
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

    void GroundCheck()
    {
        if (eye.eyeRay)
        {
            transform.Rotate(0f, 180f, 0f);
            direction *= -1;
        }
    }
    void PlayerCheck()
    {
        if (playerDetector_CircleCast.playerDetected)
        {
            if (playerDetector_CircleCast.direction == 1 && direction == -1)
            {
                transform.Rotate(0f, 180f, 0f);
                direction *= -1;
                //facingRight = true;
                Debug.Log("Player Check");
            }
            else if (playerDetector_CircleCast.direction == -1 && direction == 1)
            {
                transform.Rotate(0f, 180f, 0f);
                direction *= -1;
                //facingRight = false;
                Debug.Log("Player Check");
            }
        }
    }
}
