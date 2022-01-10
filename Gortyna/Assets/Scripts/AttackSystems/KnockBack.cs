using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockTime = 0.3f;
    public float force = 0.9f;

    private Character offender;
    private Character receiver;
    private Trap offenderTrap;

    public void DoKnockBack(Character o, Character r)
    {
        offender = o;
        receiver = r;
        
        if(receiver)
        {
            if (receiver.rigidBody)
            {
                if (receiver.rigidBody.isKinematic)
                {
                    receiver.canMove = false;
                    receiver.rigidBody.isKinematic = false;
                    //Vector2 differerence = (offender.transform.position - receiver.transform.position).normalized;
                    //receiver.rigidBody.AddForce(differerence * 50, ForceMode2D.Impulse);

                    if (offender.direction == 1)
                    {
                        receiver.rigidBody.velocity = new Vector2(1 * receiver.resistance_Horizontal, 1f * receiver.resistance_Vertical);
                    }
                    else if (offender.direction == -1)
                    {
                        receiver.rigidBody.velocity = new Vector2(-1 * receiver.resistance_Horizontal, 1f * receiver.resistance_Vertical);
                    }

                    if (receiver.GetComponent<Rigidbody2D>())
                    {
                        Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                        StartCoroutine("KnockBackCoroutineWasKinematic", (rigidbody2D));
                    }
                }
                else if (receiver.rigidBody.isKinematic == false)
                {
                    receiver.canMove = false;
                    if (offender.direction == 1)
                    {
                        receiver.rigidBody.velocity = new Vector2(1f * receiver.resistance_Horizontal, 1f * receiver.resistance_Vertical);
                        Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                        StartCoroutine("KnockBackCoroutine", (rigidbody2D));
                    }
                    else if (offender.direction == -1)
                    {
                        receiver.rigidBody.velocity = new Vector2(-1f * receiver.resistance_Horizontal, 1f * receiver.resistance_Vertical);
                        Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                        StartCoroutine("KnockBackCoroutine", (rigidbody2D));
                    }
                }
            }
            else if (receiver.rigidBody == null)
            {
                receiver.canMove = false;

                if (offender.direction == 1)
                {
                    receiver.rigidBody = gameObject.AddComponent<Rigidbody2D>();
                    receiver.rigidBody.velocity = new Vector2(1 * receiver.resistance_Horizontal, 1f * receiver.resistance_Vertical);
                    Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                    StartCoroutine("KnowBackCoroutineNoRigidBody", (rigidbody2D));
                }
                else if (offender.direction == -1)
                {
                    Rigidbody2D rigidbody2d = gameObject.AddComponent<Rigidbody2D>();
                    receiver.rigidBody = rigidbody2d;
                    receiver.rigidBody.velocity = new Vector2(-1 * receiver.resistance_Horizontal, 1f * receiver.resistance_Vertical);
                    Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                    StartCoroutine("KnowBackCoroutineNoRigidBody", (rigidbody2D));
                }
            }
        }
    }
    public void DoKnockBackFromTrap(Trap o, Character r)
    {
        offenderTrap = o;
        receiver = r;
        if (receiver.rigidBody.isKinematic == false)
        {
            receiver.canMove = false;
            if (offenderTrap.direction == 1)
            {
                receiver.rigidBody.velocity = new Vector2(1f * receiver.resistance_Horizontal, 1f * receiver.resistance_Vertical);
                Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                StartCoroutine("KnockBackCoroutine", (rigidbody2D));
            }
            else if (offenderTrap.direction == -1)
            {
                receiver.rigidBody.velocity = new Vector2(-1f * receiver.resistance_Horizontal, 1f * receiver.resistance_Vertical);
                Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                StartCoroutine("KnockBackCoroutine", (rigidbody2D));
            }
        }
    }

    private IEnumerator KnockBackCoroutine(Rigidbody2D rigidBody)
    {
        yield return new WaitForSeconds(0.8f);

        //I have modified this
        rigidBody.velocity = Vector2.zero;
        //rigidBody.isKinematic = true;

        receiver.canMove = true;
    }
    private IEnumerator KnockBackCoroutineWasKinematic(Rigidbody2D rigidBody)
    {
        yield return new WaitForSeconds(0.8f);

        //I have modified this
        rigidBody.velocity = Vector2.zero;

        rigidBody.isKinematic = true;
        receiver.canMove = true;
    }
    private IEnumerator KnowBackCoroutineNoRigidBody(Rigidbody2D rigidBody)
    {

        yield return new WaitForSeconds(0.8f);
        Destroy(rigidBody);
        receiver.canMove = true;
    }
                                
}
