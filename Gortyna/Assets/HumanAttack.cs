using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAttack : MonoBehaviour
{
    // Start is called before the first frame update
    Human human;

    public void Attack(Transform tr)
    {
        if(tr.GetComponent<Human>())
        {
            human = tr.GetComponent<Human>();

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(human.attackPoint.position, human.attackRange, human.enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(1);
                Debug.Log("We have it " + enemy.name);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (human.attackPoint == null)
            return;
        Gizmos.DrawWireSphere(human.attackPoint.position, human.attackRange);
    }
}
