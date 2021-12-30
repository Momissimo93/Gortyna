using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Character
{
    public float flyingPower;
    public void SetTransform(Transform tr)
    {
        trans = tr;
    }
    public void SetDirection(float dr)
    {
        direction = dr;
    }
    // Start is called before the first frame update
    public void SetRotation(string s)
    {

        if (s == "right")
        {
            if (direction == -1)
            {
                transform.Rotate(0f, 180f, 0f);
                direction = 1;
            }
        }
        else if (s == "left")
        {
            if (direction == 1)
            {
                transform.Rotate(0f, 180f, 0f);
                direction = -1;
            }
        }
    }
}
