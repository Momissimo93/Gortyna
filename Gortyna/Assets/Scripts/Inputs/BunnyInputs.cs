using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyInputs : MonoBehaviour
{
    public Bunny bunny;
    private float horizontalMove = 0;
    float direction;
    Rigidbody2D rb;
    Command moveRigth;
    Command moveLeft;

    void Start()
    {
        moveRigth = new MoveRight();
        moveLeft = new MoveLeft();
    }
    private void Update()
    {
        bunny = FindObjectOfType<Bunny>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (bunny)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");

            direction = horizontalMove;

            if (horizontalMove > 0)
            {
                moveRigth.Execute(bunny.transform, direction);
                bunny.animator.SetFloat("Bunny_Speed", bunny.speed);
                bunny.SetRotation("right");
            }
            else if (horizontalMove < 0)
            {
                moveLeft.Execute(bunny.transform, direction);
                bunny.animator.SetFloat("Bunny_Speed", bunny.speed);
                bunny.SetRotation("left");
            }
            else if (horizontalMove == 0)
            {
                bunny.animator.SetFloat("Bunny_Speed", 0);
                bunny.rigidBody.velocity = Vector3.zero;
            }
        }
    }
}
