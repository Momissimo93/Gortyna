using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSuspended: Trap
{
    private void Start()
    {
        damages = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            Human humam = collision.gameObject.GetComponent<Human>();
            trapsAttack.Attack(damages, humam, this.gameObject.GetComponent<TrapSuspended>());

        }
        else if (collision.gameObject.CompareTag("Bird"))
        {
            Bird bird = collision.gameObject.GetComponent<Bird>();
            trapsAttack.Attack(damages, bird, this.gameObject.GetComponent<TrapSuspended>());
        } 
    }
}
