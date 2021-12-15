using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    Character character;
    public IEnumerator Stopping(float seconds, Character c)
    {
        character = c;
        
        if(c.GetComponent<Human>())
        {
            Human h = c.GetComponent<Human>();
            for (int i = 0; i < 1; i++)
            {
                h.canMove = false;
                yield return new WaitForSeconds(seconds);
            }
            h.canMove = true;
        }
    }
}
