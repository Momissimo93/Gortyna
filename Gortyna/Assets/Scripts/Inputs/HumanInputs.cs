using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanInputs : MonoBehaviour
{
    public Human human;
    public MainCharactersManager mainCharactersManager;

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

        human = GameObject.FindObjectOfType<Human>();
        mainCharactersManager = GameObject.FindObjectOfType<MainCharactersManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (human)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && (human.isOnGround) && canMove)
            {
                human.isMoving = true;
                direction = horizontalMove;
                jump.Execute(human.transform, direction);
                //Debug.Log("Jump animation activated");
                human.animator.SetTrigger("IsJumping");
            }
            else if (human.isOnGround == true)
            {
                //Debug.Log("Jump animation De-activated");
                human.animator.ResetTrigger("IsJumping");
            }

            if (Input.GetButtonDown("Fire1") && canMove)
            {

                StartCoroutine(Stop(0.35f));
                human.rigidBody.velocity = new Vector2(0, human.rigidBody.velocity.y);
                human.animator.SetTrigger("Human_Attack");
            }

            if (Input.GetButtonDown("Fire2") && canMove)
            {
                if (!human.isDashing && canMove)
                {
                    human.isDashing = true;
                    StartCoroutine(human.Dash());
                    human.animator.SetTrigger("Dash");
                    human.isDashing = false;
                }
            }

            if (Input.GetKeyDown("q") && canMove)
            {
                if (human.canMutate_Bunny)
                {
                    mainCharactersManager.SpawnBunny(human.transform);
                }
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
        if (human)
        {
            direction = horizontalMove;

            if (horizontalMove > 0 && canMove == true)
            {
                if (human)
                {
                    human.isMoving = true;
                    MoveRight(human.transform, direction);
                    human.SetRotation("right");
                }
            }
            else if (horizontalMove < 0 && canMove == true)
            {
                human.isMoving = true;
                if (human)
                {
                    MoveLeft(human.transform, direction);
                    human.SetRotation("left");
                }
            }
            else if (horizontalMove == 0)
            {
                human.isMoving = false;
                if (human.rigidBody)
                {
                    human.rigidBody.velocity = new Vector2(0, human.rigidBody.velocity.y);
                    human.animator.SetFloat("Human_Speed", 0);
                }
            }
        }
    }

    public void MoveLeft(Transform transform, float direction)
    {
        human.animator.SetFloat("Human_Speed", human.speed);
        moveLeft.Execute(transform, direction);
    }
    public void MoveRight(Transform transform, float direction)
    {
        human.animator.SetFloat("Human_Speed", human.speed);
        moveRight.Execute(transform, direction);
    }

}
