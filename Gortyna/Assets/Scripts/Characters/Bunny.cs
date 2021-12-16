using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : Character
{
    protected bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        //SetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTransform (Transform tr)
    {
        trans = tr;
    }
    public void SetDirection (float dr)
    {
        direction = dr;
        //Debug.Log("Bunny direction " + direction);

        /*if (direction == -1)
        {
            Debug.Log("is facing left");
            facingRight = false;
            Debug.Log("Facing right = " + facingRight);
        }
        else
        {
            Debug.Log("is facing rigth");
            facingRight = true;
            Debug.Log("Facing right = " + facingRight);
        }*/
    }

    private void SetDirection()
    {
        /*float localEu = trans.localEulerAngles.y;
        Debug.Log(localEu);

        if (localEu == -180)
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
        }*/
    }

    public void SetRotation(string s)
    {
        Debug.Log("The character is moving " + s);

        if (s == "right")
        {
            if (direction == -1)
            {
                Debug.Log("is facing right was " + facingRight);
                transform.Rotate(0f, 180f, 0f);
                //facingRight = true;
                Debug.Log("is facing right is " + facingRight);
                direction = 1;
            }
        }
        else if (s == "left")
        {
            if (direction == 1)
            {
                Debug.Log("is facing right was " + facingRight);
                transform.Rotate(0f, 180f, 0f);
                //facingRight = false;
                Debug.Log("is facing right is " + facingRight);
                direction = -1;
            }
        }
    }
}
