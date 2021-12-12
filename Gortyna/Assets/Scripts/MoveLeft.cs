using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft: Command
{
    public override void Execute(Transform trans, float direction)
    {
        Move(trans, direction);
    }

    public override void Move(Transform trans, float direction)
    {
        if(trans.gameObject.GetComponent<Character>())
        {
            Debug.Log("Is a character");
            character = trans.gameObject.GetComponent<Character>();

            if (trans.gameObject.GetComponent<Rigidbody2D>())
            {
                rb = trans.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(direction * character.speed * Time.deltaTime, rb.velocity.y);
            }
            else
            {
                //Debug.Log("LET'S FUCKING MOVE IT");
                trans.position = new Vector2(trans.position.x + (3 * direction * Time.deltaTime), trans.position.y);
            }
        }
        else
        {
            Debug.Log("Error");
        }
    }
}
