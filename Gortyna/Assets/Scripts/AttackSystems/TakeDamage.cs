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
    public Trap offenderTrap;
    [HideInInspector]
    public Blinking blinking;
    [HideInInspector]
    public Immunity immunity;
    [HideInInspector]
    public StopAnimation stopAnimation;
    [HideInInspector]
    public KnockBack knockBack;
    HeartsHealthVisual heartsHealthVisual;
    void Start()
    {
        knockBack = gameObject.AddComponent<KnockBack>();
        blinking = gameObject.AddComponent<Blinking>();
        immunity = gameObject.AddComponent<Immunity>();
        stopAnimation = gameObject.AddComponent<StopAnimation>();
        heartsHealthVisual = GameObject.FindObjectOfType<HeartsHealthVisual>();
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

        if (receiver.gameObject.GetComponent<Enemy>())
        {
            Enemy e = receiver.gameObject.GetComponent<Enemy>();
            if (e.immune == false)
            {
                e.currentLifePoints -= damage;

                if (e.currentLifePoints <= 0)
                {
                    //Just so it does not hurt us touching us 
                    e.isDeath = true;
                    knockBack.DoKnockBack(offender, e);   
                    e.speed = 0;
                    e.animator.SetFloat("Speed", 0);
                    e.animator.SetTrigger("Death");
                    StartCoroutine("DeathCoroutine", e);
                }

                else if (e.currentLifePoints > 0)
                {
                    stopAnimation.DoStopAnimation(e, 1f);
                    knockBack.DoKnockBack(offender, e);
                    immunity.DoImmunity(e, 1f);
                }
            }
        }
        //If it is the Bird or the Human
        else 
        {
            stopAnimation.DoStopAnimation(receiver, 1f);
            knockBack.DoKnockBack(offender, receiver);
            immunity.DoImmunity(receiver, 1f);
            heartsHealthVisual.HeartHealthSystemOnDamaged(damage);
        }
    }
    public void DoTakeDamageFromTrap(int d, Trap ofd, Character rcv)
    {
        receiver = rcv;
        offenderTrap = ofd;
        int damage = d;

        stopAnimation.DoStopAnimation(receiver, 1f);
        knockBack.DoKnockBackFromTrap(ofd, receiver);
        immunity.DoImmunity(receiver, 1f);
        heartsHealthVisual.HeartHealthSystemOnDamaged(damage);
    }
    public IEnumerator DeathCoroutine(Enemy e)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(e.gameObject);
    }
}

