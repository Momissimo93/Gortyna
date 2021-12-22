using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immunity : MonoBehaviour
{
    public void DoImmunity(Character cr, float seconds)
    {
        StartCoroutine(ImmunityCoroutine(cr,seconds));
    }

    IEnumerator ImmunityCoroutine (Character character, float seconds)
    {
        if (character)
        {
            character.immune = true;
            //character.boxCollider2D.isTrigger = true;

            for (int i = 0; i < seconds; i++)
            {
                //it runs 3 times and at each iteration it stops for a second --> so in total the characters will blink for 3 seconds
                yield return new WaitForSeconds(seconds);
            }

            RestoreRightAlpha(character);
            character.immune = false;
            //character.boxCollider2D.isTrigger = false;
            //Debug.Log("The character is not immune");
        }
    }

    public void RestoreRightAlpha(Character character)
    {
        if (character)
        {
            if (character.GetComponent<SpriteRenderer>())
            {
                SpriteRenderer spriteRenderer;
                spriteRenderer = character.GetComponent<SpriteRenderer>();
                Color tempColor = spriteRenderer.color;

                if (spriteRenderer.color.a == 0)
                {
                    tempColor.a = 1f;
                    spriteRenderer.color = tempColor;
                    //Debug.Log("Alpha Restored");
                }
                else
                {
                    //Debug.Log("There is no need for restoring Alpha Restored");
                }
            }
        }
    }
}
