using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanInputs : MonoBehaviour
{
    [SerializeField] private Human human;
    [SerializeField] private HumanAttack attack;

    private MainCharactersManager mainCharactersManager;
    private PauseMenu pauseMenu;
    private Command moveLeft;
    private Command moveRight;
    private Command jump;
    private Command hero_Attack;
    private Dash dash;
    private Stop stop;
    private float horizontalMove = 0;
    private float direction;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        jump = new Jump();
        moveLeft = new MoveLeft();
        moveRight = new MoveRight();
        hero_Attack = new Hero_Attack();
        dash = gameObject.AddComponent<Dash>();
        stop = gameObject.AddComponent<Stop>();
        human = GameObject.FindObjectOfType<Human>();
        mainCharactersManager = GameObject.FindObjectOfType<MainCharactersManager>();
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
        human.canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (human && human.canMove && pauseMenu.gameIsPause == false)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            direction = horizontalMove;

            if (Input.GetButtonDown("Jump") && human.isOnGround)
            {
                human.isMoving = true;
                isJumping = true;
                jump.Execute(human.transform, direction);
            }

            if (Input.GetButtonDown("Fire1")  && human.isOnGround && !human.isDashing )
            {
                StartCoroutine(stop.Stopping(0.35f,human));
                human.rigidBody.velocity = new Vector2(0, human.rigidBody.velocity.y);
                human.animator.SetTrigger("Human_Attack");
                attack.DoHumanAttack(human);
            }

            if (Input.GetButtonDown("Fire2") && human.canMove)
            {
                if (!human.isDashing)
                {
                    StartCoroutine(dash.Dashing(human));
                }
            }

            if (Input.GetKeyDown("q"))
            {
                if (human.canMutate_Bunny)
                {
                    mainCharactersManager.SpawnBunny(human.transform);
                }
                else if (human.canMutate_Bird)
                {
                    mainCharactersManager.SpawnBird(human.transform);
                }
            }
        }
        else if (human.isOnGround)
        {
            isJumping = false;
        }
    }
    private void FixedUpdate()
    {
        if (human && human.canMove)
        {
            direction = horizontalMove;

            if (horizontalMove > 0 && !human.isDashing)
            {
                if (human)
                {
                    human.isMoving = true;
                    human.animator.SetFloat("Speed", human.speed);
                    moveRight.Execute(human.transform, direction);
                    human.SetRotation("right");
                }
            }
            else if (horizontalMove < 0  && !human.isDashing)
            {
                if (human)
                {
                    human.isMoving = true;
                    human.animator.SetFloat("Speed", human.speed);
                    moveLeft.Execute(human.transform, direction);
                    human.SetRotation("left");
                }
            }
            else if (horizontalMove == 0 && !human.isDashing)
            {
                if (human.rigidBody)
                {
                    human.rigidBody.velocity = new Vector2(0, human.rigidBody.velocity.y);
                    human.animator.SetFloat("Speed", 0);
                }
            }
        }
    }
}
