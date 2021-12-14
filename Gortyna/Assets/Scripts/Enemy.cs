using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    Command moveLeft;
    Command moveRight;

    void Start()
    {
        moveLeft = new MoveLeft();
        moveRight = new MoveRight();
    }

    public void MoveLeft()
    {
        moveLeft.Execute(trans, -1);
    }

    public void MoveRight()
    {
        moveRight.Execute(trans, 1);
    }
}
