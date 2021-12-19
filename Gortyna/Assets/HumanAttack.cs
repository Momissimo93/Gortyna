using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAttack : MonoBehaviour
{
    // Start is called before the first frame update
    Human human;
    public float knockTime = 0.5f;

    public void Attack(Transform tr)
    {
        if (tr.GetComponent<Human>())
        {
            human = tr.GetComponent<Human>();

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(human.attackPoint.position, human.attackRange, human.enemyLayer);

            foreach (Collider2D e in hitEnemies)
            {
                StartCoroutine(TakeDamageCoroutine(e.GetComponent<Enemy>()));

                if(e.GetComponent<Enemy>().currentLifePoints > 0 )
                {
                    Enemy enemy = e.GetComponent<Enemy>();
                    KnockBack(enemy);
                    Debug.Log("We have it " + enemy.name);
                }
            }
        }
    }

    private IEnumerator TakeDamageCoroutine(Enemy enemy)
    {
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<Enemy>().TakeDamage(1);
    }

    private void KnockBack(Enemy enemy)
    {
        enemy.rigidBody.isKinematic = false;
        Vector2 differerence = enemy.rigidBody.transform.position - human.transform.position;
        differerence = differerence.normalized * 800f;
        Debug.Log("Difference = " + differerence);

        //enemy.rigidBody.AddForce(differerence, ForceMode2D.Impulse);
        enemy.rigidBody.AddForce(differerence);

        if (enemy.GetComponent<Rigidbody2D>())
        {
            Rigidbody2D rigidbody2D = enemy.GetComponent<Rigidbody2D>();
            StartCoroutine(KnockCoroutine(rigidbody2D));
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D rigidBody)
    {
        yield return new WaitForSeconds(0.3f);
        rigidBody.velocity = Vector2.zero;
        rigidBody.isKinematic = true;
    }


    void OnDrawGizmosSelected()
    {
        if (human.attackPoint == null)
            return;
        Gizmos.DrawWireSphere(human.attackPoint.position, human.attackRange);
    }
}
