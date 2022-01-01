using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockTime = 0.3f;
    public float force = 0.9f;

    private Character offender;
    private Character receiver;

    public void DoKnockBack(Character o, Character r)
    {
        offender = o;
        receiver = r;  

        if (receiver.rigidBody.isKinematic)
        {
            receiver.canMove = false;
            receiver.rigidBody.isKinematic = false;
            //Vector2 differerence = (offender.transform.position - receiver.transform.position).normalized;
            //receiver.rigidBody.AddForce(differerence * 50, ForceMode2D.Impulse);

            if(offender.direction == 1)
            {
                receiver.rigidBody.velocity = new Vector2(1 * force, 2f * force);
            }
            else if (offender.direction == -1)
            {
                receiver.rigidBody.velocity = new Vector2(-1 * force, 2f * force);
            }

            if (receiver.GetComponent<Rigidbody2D>())
            {
                Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                StartCoroutine("KnockBackCoroutine", (rigidbody2D));
            }
        }
        else if (receiver.rigidBody.isKinematic == false)
        {
            receiver.canMove = false;
            if (offender.direction == 1)
            {
                receiver.rigidBody.velocity = new Vector2 (0.5f * force, 6f * force);
                Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                StartCoroutine("KnockBackCoroutine", (rigidbody2D));
            }
            else if (offender.direction == -1)
            {
                receiver.rigidBody.velocity = new Vector2(-0.5f * force, 6f * force);
                Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                StartCoroutine("KnockBackCoroutine", (rigidbody2D));
            }
        }
    }

    private IEnumerator KnockBackCoroutine(Rigidbody2D rigidBody)
    {
        yield return new WaitForSeconds(0.8f);
        //rigidBody.velocity = Vector2.zero;
        //rigidBody.isKinematic = true;
        receiver.canMove = true;
    }
}
