using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Command
{
    public override void Execute(Transform trans, float direction)
    {
        JumpCommand(trans);
    }
    public override void JumpCommand(Transform trans)
    {
        if (trans.gameObject.GetComponent<Rigidbody2D>())
        {
            Human human = trans.gameObject.GetComponent<Human>();
            rb = trans.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, human.jumpForce);
        }
        else
        {
            Debug.Log("I can not jump");
        }
    }
}
