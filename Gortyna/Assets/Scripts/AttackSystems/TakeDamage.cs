using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [HideInInspector]
    public Character receiver;
    [HideInInspector]
    public Character offender;
    [HideInInspector]
    public Blinking blinking;
    [HideInInspector]
    public Immunity immunity;
    [HideInInspector]
    public StopAnimation stopAnimation;
    [HideInInspector]
    public KnockBack knockBack;
    
    void Start()
    {
        //character = gameObject.GetComponent<Character>();

        knockBack = gameObject.AddComponent<KnockBack>();
        blinking = gameObject.AddComponent<Blinking>();
        immunity = gameObject.AddComponent<Immunity>();
        stopAnimation = gameObject.AddComponent<StopAnimation>();
    }
    void FixedUpdate()
    {
        if (receiver)
        {
            if (receiver.immune)
            {
                blinking.DoBlink(receiver);
            }
            else
            {
                //Debug.Log("Receiver is not immune");
            }
        }
    }

    public void DoTakeDamage(int d, Character ofd, Character rcv)
    {
        receiver = rcv;
        offender = ofd;

        int damage = d;

        if (this.receiver)
        {
            if (this.receiver.immune == false)
            {
                receiver.currentLifePoints -= damage;

                if (receiver.currentLifePoints <= 0)
                {
                    Destroy(receiver.gameObject);
                }

                else if (receiver.currentLifePoints > 0)
                {
                    stopAnimation.DoStopAnimation(receiver, 1f);
                    knockBack.DoKnockBack(offender, receiver);
                    immunity.DoImmunity(receiver, 1f);
                }
            }
        }
     }
}

