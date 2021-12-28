using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    public void DoBlink(Character character)
    {
        if (character)
        {
            if (character.GetComponent<SpriteRenderer>())
            {
                //Debug.Log("Let's blink");
                SpriteRenderer spriteRenderer;
                spriteRenderer = character.GetComponent<SpriteRenderer>();
                Color tempColor = spriteRenderer.color;

                if (spriteRenderer.color.a == 0)
                {
                    tempColor.a = 1f;
                    spriteRenderer.color = tempColor;
                    Debug.Log("1");
                }

                else if (spriteRenderer.color.a == 1)
                {
                    tempColor.a = 0f;
                    spriteRenderer.color = tempColor;
                    Debug.Log("0");
                }
            }
        }
    }
}
