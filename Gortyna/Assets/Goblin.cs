using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Goblin: Enemy
{
    public AIPlayerDetector_CircleCast playerDetector_CircleCast;
    public Eye eye;
    private bool isAttacking = false;

    void Update()
    {
        eye.EmittingRay(direction);
        eye.DrawRaysFromFeet(direction);
        GroundCheck();
        PlayerCheck();

        //With the last check we make sure that he is still alive. If not it will miss the reference 
        if (playerDetector_CircleCast.playerDetected && canMove && playerDetector_CircleCast.Target)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(playerDetector_CircleCast.Target.transform.position.x, transform.position.y, playerDetector_CircleCast.Target.transform.position.y), speed * Time.deltaTime);
            if (playerDetector_CircleCast.attack == true)
            {
                if(isAttacking == false)
                {
                    speed = 0;
                    animator.SetFloat("Speed", speed);
                    StartCoroutine("Attack");
                }
            }
            else
            {
                speed = 1;
                animator.SetBool("Attack", false);
                animator.SetFloat("Speed", speed);
            }
        }
        else
        {
            if (canMove)
            {
                HorizontalMovement();
                //This speed variable has been added just in case it get stuck 
                speed = 1;
                animator.SetFloat("Speed", speed);
                //Debug.Log("HorizontalMove");
            }
            else if (canMove == false)
            {
                Debug.Log("I can not move");
                speed = 0;
                animator.SetFloat("Speed", speed);
                animator.SetBool("Attack", false);
            }
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
                Debug.Log("Player Check");
            }
            else if (playerDetector_CircleCast.direction == -1 && direction == 1)
            {
                transform.Rotate(0f, 180f, 0f);
                direction *= -1;
                Debug.Log("Player Check");
            }
        }
    }
    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
        animator.SetBool("Attack", false);

    }

}
