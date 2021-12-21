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
    /*
    private void KnockBack(Human human)
    {
        //human.rigidBody.isKinematic = false;
        Vector2 differerence = human.rigidBody.transform.position - human.transform.position;
        differerence = differerence.normalized * 800f;
        //Debug.Log("Difference = " + differerence);

        //enemy.rigidBody.AddForce(differerence, ForceMode2D.Impulse);
        human.rigidBody.AddForce(differerence);

        if (human.GetComponent<Rigidbody2D>())
        {
            Rigidbody2D rigidbody2D = human.GetComponent<Rigidbody2D>();
            StartCoroutine(KnockCoroutine(rigidbody2D));
        }
    }
    private IEnumerator KnockCoroutine(Rigidbody2D rigidBody)
    {
        yield return new WaitForSeconds(0.3f);
        rigidBody.velocity = Vector2.zero;
        //rigidBody.isKinematic = true;
    }*/
}
