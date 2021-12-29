using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart
{
    private int status;

    //The Heart game object needs to know it's status  
    public Heart(int status)
    {
        this.status = status;
    }

    public int GetStatus()
    {
        return status;
    }

    //Do not know if needed or not
    /*public void SetStatus(int status)
    {
        this.status = status;
    }*/

    //When we are hit this Heart will have status of 0. This will signal the system to change the sprite to that of an empty heart 
    public void Damage()
    {
        status = 0;
    }

    //When we heal  this Heart will have a status of 1. This will signal the system to change the sprite to that of a full heart 
    public void Heal()
    {
        status = 1;
    }
}

