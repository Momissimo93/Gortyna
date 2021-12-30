using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Command
{
    public override void Execute(Transform trans, float direction)
    {
        FlyingCommand(trans);
    }
    public override void FlyingCommand(Transform trans)
    {
        if (trans.gameObject.GetComponent<Rigidbody2D>())
        {
            Bird bird = trans.gameObject.GetComponent<Bird>();
            bird.rigidBody = trans.gameObject.GetComponent<Rigidbody2D>();
            bird.rigidBody.velocity = new Vector2(bird.rigidBody.velocity.x/4, bird.flyingPower);
        }
        else
        {
            //Debug.Log("I can not jump");
        }
    }
}
