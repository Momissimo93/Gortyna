using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInput : MonoBehaviour
{
    public Bird bird;
    private float horizontalMove = 0;
    private float direction;
    private Rigidbody2D rb;
    private Command moveRigth;
    private Command moveLeft;
    private Command fly;

    // Start is called before the first frame update
    void Start()
    {
        moveRigth = new MoveRight();
        moveLeft = new MoveLeft();
        fly = new Fly();
    }
    private void FixedUpdate()
    {
       Move();
    }

    // Update is called once per frame
    void Update()
    {
        bird = FindObjectOfType<Bird>();

        if (Input.GetButtonDown("Jump"))
        {
            direction = horizontalMove;
            fly.Execute(bird.transform, direction);
        }
    }
    private void Move()
    {
        if (bird)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            direction = horizontalMove;

            if (horizontalMove > 0f)
            {
                moveRigth.Execute(bird.transform, direction);
                bird.SetRotation("right");
                if (bird.isOnGround == true)
                {
                    bird.animator.SetFloat("Speed", bird.speed);
                }
            }
            else if (horizontalMove < 0f)
            {
                moveLeft.Execute(bird.transform, direction);
                bird.SetRotation("left");
                if (bird.isOnGround == true)
                {
                    bird.animator.SetFloat("Speed", bird.speed);
                }
            }
            else 
            {
                bird.rigidBody.velocity = new Vector2(0f, bird.rigidBody.velocity.y);
                if (bird.isOnGround == true)
                {
                    bird.animator.SetFloat("Speed", 0f);
                }
            }
        }
    }
}
