using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponent<Character>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (character.immune)
        {
            Blinking();
        }
    }

    public void TakeDamage(int d)
    {
        int damage = d;

        if (character)
        {
            if (character.immune == false)
            {
                if (character.currentLifePoints <= 0)
                {
                    Destroy(character.gameObject);
                }
                else
                    character.currentLifePoints -= damage;
                    StartCoroutine("Immunity", 2f);
            }
        }
    }

    IEnumerator Immunity(float seconds)
    {
        character.immune = true;

        if (character)
        {
            for (int i = 0; i < seconds; i++)
            {
                //it runs 3 times and at each iteration it stops for a second --> so in total the characters will blink for 3 seconds
                yield return new WaitForSeconds(1f);
            }
            RestoreRightAlpha();
            character.immune = false;
        }
    }

    public void RestoreRightAlpha()
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
                    Debug.Log("Alpha Restored");
                }
                else
                    Debug.Log("There is no need for restoring Alpha Restored");
            }
        }
    }

    protected void Blinking()
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
                }

                else if (spriteRenderer.color.a == 1)
                {
                    tempColor.a = 0f;
                    spriteRenderer.color = tempColor;
                }
            }
        }
    }
}
