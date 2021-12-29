using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealthSystem
{
    public const int MAX_STATUS_AMOUNT = 1;

    private List<Heart> heartList;

    private int initialLifePoint;
    private int lifePoints;
    public HeartHealthSystem (int heartAmount)
    {
        //Depending on the number of hearts the player has (heartAmount) a number of Heart gameObject is created and added to the list heartList
        heartList = new List<Heart>();
 
        initialLifePoint = heartAmount;
        lifePoints = initialLifePoint;

        for (int i = 0; i < heartAmount; i ++)
        {
            Heart heart = new Heart(1);
            heartList.Add(heart);
        }
    }

    //The method return a List of Heart. This List is used by the fucntion SetHeartHealthSystem, which is inside the class HeartsHealthVisual 
    public List<Heart> GetHeartList()
    {
        return heartList;
    }

    /*
     * This method is connected to the external world. The gameObject that holds a reference to the HearthHealthSystem can signal throught this method call the the player has been hit.
     * The function needs to know the amount of damages
    */

    //This method is called by the HeartHealthVisual 
    public void Damage (int damageAmount)
    {
        lifePoints = lifePoints - damageAmount;

        //Cycle through all hearts starting from the end 
        for (int i = heartList.Count - 1; i >= 0; i --)
        {
            //Test if this heart can absorb the totality of current damageAmount
            Heart heart = heartList[i];

            if (damageAmount > heart.GetStatus())
            {
                //if it can NOT absorb it then we reduce the damage amount by the amount they absorbed 
                damageAmount = damageAmount - heart.GetStatus();
                //if this happens we go into the next heart and we do again the same process (Recursion)
                heart.Damage();
            }
            else
            {
                //When we find an heart that can absorb the full damage, it takes the damage it can absorb and we break out of the cycle 
                heart.Damage();
                break; //End of the recursion 
            }
        }
     
        if (IsDead())
        {
            Debug.Log("DEAD");
        }
    }

    public void Heal(int healAmount)
    {
        lifePoints = lifePoints + healAmount;

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

    public int GetLifePoints()
    {
        return lifePoints;
    }
    public int GetInitialLifePoints()
    {
        return initialLifePoint;
    }
}
