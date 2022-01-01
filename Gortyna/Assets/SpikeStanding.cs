using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeStanding : Trap
{
    private void Start()
    {
        damages = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Bird>())
        {
            Bird bird = collision.gameObject.GetComponent<Bird>();
            direction = bird.direction * -1;
            trapsAttack.Attack(damages, bird, gameObject.GetComponent<SpikeStanding>());
        }
    }
}
