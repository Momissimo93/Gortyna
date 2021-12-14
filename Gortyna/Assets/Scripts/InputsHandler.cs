using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsHandler: MonoBehaviour
{
    public HumanForm hero;

    Command moveLeft;
    Command moveRight;
    Command jump;
    Command hero_Attack;

    private float horizontalMove = 0;
    float direction;

    bool isJumping;
    bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        jump = new Jump();
        moveLeft = new MoveLeft();
        moveRight = new MoveRight();
        hero_Attack = new Hero_Attack();
        canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && (hero.isOnGround) && canMove)
        {
            hero.isMoving = true;
            direction = horizontalMove;
            jump.Execute(hero.transform, direction);
            //Debug.Log("Jump animation activated");
            hero.animator.SetTrigger("IsJumping");
        }
        else if (hero.isOnGround == true)
        {
            //Debug.Log("Jump animation De-activated");
            hero.animator.ResetTrigger("IsJumping");
        }

        if(Input.GetButtonDown("Fire1") && canMove)
        {

            StartCoroutine(Stop(0.35f));
            hero.rigidBody.velocity = new Vector2(0, hero.rigidBody.velocity.y);
            hero.animator.SetTrigger("Human_Attack");
        }

        if (Input.GetButtonDown("Fire2") && canMove)
        {
            if(!hero.isDashing && canMove)
            {
                hero.isDashing = true;
                StartCoroutine(hero.Dash());
                hero.animator.SetTrigger("Dash");
                hero.isDashing = false;
            }
        }
    }

    IEnumerator Stop(float seconds)
    {
        for (int i = 0; i < 1; i++)
        {
            canMove = false;
            yield return new WaitForSeconds(seconds);
        }
        canMove = true;
    }

    private void FixedUpdate()
    {
        direction = horizontalMove;

        if (horizontalMove > 0 && canMove == true)
        {
            if (hero)
            {
                hero.isMoving = true;
                MoveRight(hero.transform, direction);
                hero.SetRotation("right");
            }
        }
        else if (horizontalMove < 0 && canMove == true)
        {
            hero.isMoving = true;
            if (hero)
            {
                MoveLeft(hero.transform, direction);
                hero.SetRotation("left");
            }
        }
        else if (horizontalMove == 0)
        {
            hero.isMoving = false;
            if (hero.rigidBody)
            {
                hero.rigidBody.velocity = new Vector2(0, hero.rigidBody.velocity.y);
                hero.animator.SetFloat("Human_Speed", 0);
            }
        }
    }

    public void MoveLeft(Transform transform, float direction)
    {
        hero.animator.SetFloat("Human_Speed", hero.speed);
        moveLeft.Execute(transform, direction);
    }
    public void MoveRight(Transform transform, float direction)
    {
        hero.animator.SetFloat("Human_Speed", hero.speed);
        moveRight.Execute(transform, direction);
    }

}
