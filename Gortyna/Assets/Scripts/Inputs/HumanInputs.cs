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
    Dash dash;
    Stop stop;
    HumanAttack attack;

    private float horizontalMove = 0;
    float direction;

    bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        jump = new Jump();
        moveLeft = new MoveLeft();
        moveRight = new MoveRight();
        hero_Attack = new Hero_Attack();
        dash = gameObject.AddComponent<Dash>();
        stop = gameObject.AddComponent<Stop>();
        attack = gameObject.AddComponent<HumanAttack>();
        //attack = new HumanAttack(); dash = new Dash(); stop = new Stop();

        human = GameObject.FindObjectOfType<Human>();
        mainCharactersManager = GameObject.FindObjectOfType<MainCharactersManager>();
        human.canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (human)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && (human.isOnGround) && human.canMove)
            {
                human.isMoving = true;
                direction = horizontalMove;
                jump.Execute(human.transform, direction);
                human.animator.SetTrigger("IsJumping");
            }

            if (human.isOnGround == true)
            {
                human.animator.ResetTrigger("IsJumping");
            }

            if (Input.GetButtonDown("Fire1") && human.canMove)
            {
                StartCoroutine(stop.Stopping(0.35f,human));
                human.rigidBody.velocity = new Vector2(0, human.rigidBody.velocity.y);
                human.animator.SetTrigger("Human_Attack");
                attack.DoHumanAttack(human);
            }

            if (Input.GetButtonDown("Fire2") && human.canMove)
            {
                if (!human.isDashing && human.canMove)
                {
                    human.animator.SetTrigger("Dash");
                    StartCoroutine(dash.Dashing(human));
                }
            }

            if (Input.GetKeyDown("q") && human.canMove)
            {
                if (human.canMutate_Bunny)
                {
                    mainCharactersManager.SpawnBunny(human.transform);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (human)
        {
            direction = horizontalMove;

            if (horizontalMove > 0 && human.canMove == true && human.isDashing == false)
            {
                if (human)
                {
                    human.isMoving = true;
                    human.animator.SetFloat("Human_Speed", human.speed);
                    moveRight.Execute(human.transform, direction);
                    human.SetRotation("right");
                }
            }
            else if (horizontalMove < 0 && human.canMove == true && human.isDashing == false)
            {
                if (human)
                {
                    human.isMoving = true;
                    human.animator.SetFloat("Human_Speed", human.speed);
                    moveLeft.Execute(human.transform, direction);
                    human.SetRotation("left");
                }
            }
            else if (horizontalMove == 0 && human.isDashing == false)
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
}
