using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : Attack
{
    HeartsHealthVisual heartsHealthVisual;

    private void Start()
    {
        heartsHealthVisual = FindObjectOfType<HeartsHealthVisual>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Human human = collision.gameObject.GetComponent<Human>();

            //Attack(1, human, this.gameObject.GetComponent<BombAttack>());
        }
        else
            Debug.Log("is not the hero");
    }
    public void Attack(int damages, Character rcv, Trap ofend)
    {
        receiver = rcv;
        offenderTrap = ofend;

        if (heartsHealthVisual == true && receiver.immune == false)
        {
            //We update the visual system that will update the number of life that we have 
            //receiver.currentLifePoints -= damages;
            SetReceiver(receiver);
            receiver.TakeDamageFromTrap(1, offenderTrap, receiver);
        }
    }
}
