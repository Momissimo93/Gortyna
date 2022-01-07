using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour
{
    public void DoStopAnimation (Character cr, float seconds)
    {
        StartCoroutine(StopAnimationCoroutine (cr, seconds));
    }

    IEnumerator StopAnimationCoroutine(Character character, float seconds)
    {
        float originalSpeed = character.speed;
        character.speed = 0;
         character.animator.SetFloat("Speed", character.speed);

        if (character)
        {
            for (int i = 0; i < seconds; i++)
            {
               
                yield return new WaitForSeconds(seconds);
            }

            character.immune = false;
        }

        character.speed = originalSpeed;
        character.animator.SetFloat("Speed", character.speed);
    }
}
