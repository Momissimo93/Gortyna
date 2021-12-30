using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInput : MonoBehaviour
{
    public Bird bird;
    private float horizontalMove = 0;
    float direction;
    Rigidbody2D rb;
    Command moveRigth;
    Command moveLeft;
    Command fly;

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

            if (horizontalMove > 0)
            {
                moveRigth.Execute(bird.transform, direction);
                //bunny.animator.SetFloat("Bunny_Speed", bunny.speed);
                bird.SetRotation("right");
            }
            else if (horizontalMove < 0)
            {
                moveLeft.Execute(bird.transform, direction);
                //bunny.animator.SetFloat("Bunny_Speed", bunny.speed);
                bird.SetRotation("left");
            }
            else if (horizontalMove == 0)
            {
                //bunny.animator.SetFloat("Bunny_Speed", 0);
                 //bird.rigidBody.velocity = Vector3.zero;
            }

        }
    }
}
