using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockTime = 0.3f;

    public void DoKnockBack(Character offender, Character receiver)
    {
        if (receiver.rigidBody.isKinematic)
        {
            Debug.Log("Let's get knocked back");
            receiver.rigidBody.isKinematic = false;
            Vector2 differerence = (offender.transform.position - receiver.transform.position).normalized;
            receiver.rigidBody.AddForce(differerence * 800f) ;

            if (receiver.GetComponent<Rigidbody2D>())
            {
                Rigidbody2D rigidbody2D = receiver.GetComponent<Rigidbody2D>();
                StartCoroutine("KnockBackCoroutine", (rigidbody2D));
            }
        }
    }

    private IEnumerator KnockBackCoroutine(Rigidbody2D rigidBody)
    {
        yield return new WaitForSeconds(0.5f);
        rigidBody.velocity = Vector2.zero;
        rigidBody.isKinematic = true;
    }
}
