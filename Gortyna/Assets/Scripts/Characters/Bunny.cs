using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : Character
{
    protected bool facingForward = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetRotation(string s)
    {
        if (s == "right")
        {
            if (!facingForward)
            {
                transform.Rotate(0, 180f, 0f);
                facingForward = true;
            }
        }
        else if (s == "left")
        {
            if (facingForward)
            {
                transform.Rotate(0f, 180f, 0f);
                facingForward = false;
            }
        }
    }
}
