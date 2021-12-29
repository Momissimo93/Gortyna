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
            heartsHealthVisual.HeartHealthSystemOnDamaged(1);
            receiver.currentLifePoints -= damages;
        }
        SetReceiver(receiver);
        receiver.TakeDamage(1, offender, receiver);
    }
}
