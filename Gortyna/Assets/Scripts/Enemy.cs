using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    Command moveLeft;
    Command moveRight;

    void Awake()
    {
        moveLeft = new MoveLeft();
    }

    public void MoveLeft()
    {
        if(moveLeft != null && trans != null)
        {
            moveLeft.Execute(trans, direction);
        }
    }
}
