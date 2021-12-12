using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveLeft
{
    Character character;
    public void Move(Transform tr, float direction)
    {
        if (tr.gameObject.GetComponent<Character>())
        {
            character = tr.gameObject.GetComponent<Character>();

            tr.position = new Vector2(tr.position.x, tr.position.y + (2 * direction * Time.deltaTime));

        }
        else
        {
            Debug.Log("Error");
        }
    }
}
