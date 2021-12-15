using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyInputsHandler : MonoBehaviour
{
    public Bunny bunny;
    private float horizontalMove = 0;
    float direction;
    Rigidbody2D rb;
    Command moveRigth;
    Command moveLeft;
    // Start is called before the first frame update

    void Start()
    {
        moveRigth = new MoveRight();
        moveLeft = new MoveLeft();
    }
    private void Update()
    {
        //
        bunny = FindObjectOfType<Bunny>();
        Move();
    }

    // Update is called once per frame
    private void Move()
    {
        if (bunny)
        {
            Debug.Log("Let's try to move");

            horizontalMove = Input.GetAxisRaw("Horizontal");

            direction = horizontalMove;

            if (horizontalMove < 0)
            {
                moveRigth.Execute(bunny.transform, -1);
                bunny.animator.SetFloat("Bunny_Speed", bunny.speed);
                bunny.SetRotation("right");
            }
            else if (horizontalMove > 0 )
            {
                moveLeft.Execute(bunny.transform, 1);
                bunny.animator.SetFloat("Bunny_Speed", bunny.speed);
                bunny.SetRotation("left");
            }
            else if (horizontalMove == 0)
            {
                bunny.animator.SetFloat("Bunny_Speed", 0);
            }
        }
    }
}
