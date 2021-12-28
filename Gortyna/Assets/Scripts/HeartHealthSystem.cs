using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealthSystem
{
    public const int MAX_STATUS_AMOUNT = 1;

    //public event EventHandler onDamage;
    //public event EventHandler onHealed;

    private List<Heart> heartList;

    public HeartHealthSystem (int heartAmount)
    {
        heartList = new List<Heart>();
        for (int i = 0; i < heartAmount; i ++)
        {
            Heart heart = new Heart(1);
            heartList.Add(heart);
        }
        //heartList[heartList.Count - 1].setStatus(0);

    }

    public List<Heart> GetHeartList()
    {
        return heartList;
    }

    public void Damage (int damageAmount)
    {
        //Cycle through all hearts starting from the end 
        for (int i = heartList.Count - 1; i >= 0; i --)
        {
            //Test if this hearth can absorb the current damageAmount
            Heart heart = heartList[i];
            if (damageAmount > heart.GetStatus())
            {
                Debug.Log("This heart can NOT take the full damage");
                //if it can NOT absorb it then we reduce the damage amount by the amount  they absorbed 
                damageAmount = damageAmount - heart.GetStatus();
                //if this happens we go into the next heart and we deal with the next damage 
                heart.Damage();
            }
            else
            {
                Debug.Log("This heart can take the full damage");
                //When we find an heart that can absorb the full damage, it takes the damage it can absorb and we break out of the cycle 
                heart.Damage();
                break;
            }
        }
        Debug.Log("Let's see if the player is still alaive");
        if (IsDead())
        {
            Debug.Log("DEAD");
        }
        //if (onDamage != null) onDamage(this, EventArgs.Empty);
    }

    public void Heal(int healAmount)
    {
        Debug.Log("Let's Heal");
        for(int i = 0; i < heartList.Count; i ++)
        {
            Heart heart = heartList[i];

            int currentStatus = MAX_STATUS_AMOUNT - heart.GetStatus(); // current status = 1 - 0 = 1

            if (currentStatus == 0)
            {
                Debug.Log("This heart is full");    
            }
            else if(healAmount > currentStatus) //2 > 1 
            {
                Debug.Log("We can heal this heart and another one");
                healAmount = healAmount - currentStatus; //healAmount = 2 - 1 = 1
                heart.Heal();
            }
            else
            {
                Debug.Log("We can heal  ONLY this heart ");
                heart.Heal();
                break;
            }

        }
        //if (onDamage != null) onHealed(this, EventArgs.Empty);
    }

    public bool IsDead()
    {
        return heartList[0].GetStatus() == 0;
    }

    public class Heart
    {
        private int status;
        public Heart(int status)
        {
            this.status = status;
        }

        public int GetStatus()
        {
            return status;
        }

        public void setStatus(int status )
        {
            this.status = status;
        }

        public void Damage()
        {
            status = 0;
        }

        public void Heal ()
        {
            status = 1;
        }
    }
}
