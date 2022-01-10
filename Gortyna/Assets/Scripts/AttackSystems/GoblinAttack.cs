using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttack : Attack
{
    private HeartsHealthVisual heartsHealthVisual;
    [SerializeField] private Character goblin;

    void Start()
    {
        heartsHealthVisual = GameObject.FindObjectOfType<HeartsHealthVisual>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Debug.Log("Hit");
            Human humam = collision.gameObject.GetComponent<Human>();
            Attack(1, humam, goblin);
        }
        else
            Debug.Log("is not the hero");   
    }
    private void Attack(int damages, Character rcv, Character ofend)
    {
        receiver = rcv;
        offender = ofend;

        if (heartsHealthVisual == true && receiver.immune == false)
        {
            //We update the visual system that will update the number of life that we have 
            //receiver.currentLifePoints -= damages;
            SetReceiver(receiver);
            receiver.TakeDamage(1, offender, receiver);
        }
    }
}
