using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmAttack : MonoBehaviour
{
    public Worm worm;
    Human human;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            human = collision.gameObject.GetComponent<Human>();

            if (human.currentLifePoints > 0)
            {
                //KnockBack(human);
                Debug.Log("We have it " + human.name);
                human.takeDamage.DoTakeDamage(1, worm, human );
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
                //KnockBack(human);
                Debug.Log("We have it " + human.name);

        }

    }

}
