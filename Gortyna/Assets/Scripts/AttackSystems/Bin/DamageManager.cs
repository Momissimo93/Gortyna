using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public Character character;
    public Blinking blinking;
    public Immunity immunity;
    public StopAnimation stopAnimation;
    public KnockBack knockBack;

    // Start is called before the first frame update
    void Start()
    {
        character = gameObject.GetComponent<Character>();

        knockBack = gameObject.AddComponent<KnockBack>();
        blinking = gameObject.AddComponent<Blinking>();
        immunity = gameObject.AddComponent<Immunity>();
        stopAnimation = gameObject.AddComponent<StopAnimation>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (character.immune)
        {
            blinking.DoBlink(character);
        }
    }

    public void TakeDamage(int d)
    {
        int damage = d;

        if (character)
        {
            if (character.immune == false)
            {
                character.currentLifePoints -= damage;

                if (character.currentLifePoints <= 0)
                {
                    Destroy(character.gameObject);
                }
                else
                    //StartCoroutine("Immunity", 1f);
                    //knockBack.DoKnockBack(human, enemy);
                    immunity.DoImmunity(character, 1f);
                    stopAnimation.DoStopAnimation(character, 1f);
                    StartCoroutine("StopAnimation", 1f);
            }
        }
    }
}

//CHANGE THE NAME TO TAKE DAMAGE