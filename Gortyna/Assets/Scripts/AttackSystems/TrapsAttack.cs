using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsAttack : Attack
{
    HeartsHealthVisual heartsHealthVisual;

    void Start()
    {
        heartsHealthVisual = GameObject.FindObjectOfType<HeartsHealthVisual>();
    }

    ///RISOLVERE QUESTA FACCENDA 
    public void Attack(int damages, Character rcv, Character ofend)
    {
        receiver = rcv;
        offender = ofend;

        if(heartsHealthVisual == true  && receiver.immune == false)
        {
            //We update the visual system that will update the number of life that we have 
            //receiver.currentLifePoints -= damages;
            SetReceiver(receiver);
            receiver.TakeDamage(1, offender, receiver);
        }
    }
}
