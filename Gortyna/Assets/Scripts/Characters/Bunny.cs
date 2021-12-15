using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : Character
{
    protected bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        SetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDirection()
    {
        float localEu = trans.localEulerAngles.y;
        Debug.Log(localEu);

        if (localEu == 180f || localEu == -180)
        {
            Debug.Log("is facing left");
            direction = -1;
            facingRight = false;
        }
        else 
        {
            Debug.Log("is facing rigth");
            direction = 1;
            facingRight = true;
        }
    }

    public void SetRotation(string s)
    {
        if (s == "right")
        {
            if (!facingRight)
            {
                transform.Rotate(0, 180f, 0f);
                facingRight = true;
                direction = 1;
            }
        }
        else if (s == "left")
        {
            if (facingRight)
            {
                transform.Rotate(0f, 180f, 0f);
                facingRight = false;
                direction = -1;
            }
        }
    }
}
