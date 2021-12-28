using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsAttack : Attack
{
    Human human;
    HeartsHealthVisual heartsHealthVisual;

    void Start()
    {
        heartsHealthVisual = GameObject.FindObjectOfType<HeartsHealthVisual>();
    }

    void FixedUpdate()
    {

    }

    ///RISOLVERE QUESTA FACCENDA 
    public void Attack(Human hm, int damages)
    {
        human = hm;
        if(heartsHealthVisual == true  && human.immune == false)
        {
            heartsHealthVisual.heartHealthSystemOnDamaged(1);
            human.currentLifePoints -= damages;
        }
        SetReceiver(hm);
        receiver.TakeDamage(1, receiver, receiver);
    }
}
