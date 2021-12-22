using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAttack : MonoBehaviour
{
    // Start is called before the first frame update
    Human human;
    //KnockBack knockBack;
    void Start()
    {
  
    }

    public void DoHumanAttack(Human hm)
    {
        if (hm.GetComponent<Human>())
        {
            human = gameObject.GetComponent<Human>();

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(human.attackPoint.position, human.attackRange, human.enemyLayer);

            foreach (Collider2D e in hitEnemies)
            {
                if (e.GetComponent<Enemy>())
                {
                    if (e.GetComponent<Enemy>().currentLifePoints > 0)
                    {
                        Enemy enemy = e.GetComponent<Enemy>();
                        StartCoroutine("HumanAttackCoroutine", (e.GetComponent<Enemy>()));
                        //Debug.Log("We have it " + enemy.name);
                    }
                }
                else
                {
                    Debug.Log("This component does not have a class Enemy");
                }
            }
        }
    }

    private IEnumerator HumanAttackCoroutine(Enemy enemy)
    {
        yield return new WaitForSeconds(0.1f);
        enemy.GetComponent<Enemy>().TakeDamage(1,human,enemy);
        //knockBack.DoKnockBack(human, enemy);
    }
}
