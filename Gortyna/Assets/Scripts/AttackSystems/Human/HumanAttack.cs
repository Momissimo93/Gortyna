using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAttack : Attack
{
    // Start is called before the first frame update
    public float rangeRadius;
    Vector2 rangeOrigin;
    Human human;

    //KnockBack knockBack;
    void Start()
    {

        rangeOrigin = transform.position;
        offenderLayer = 1 << 8;
        //SetOffender(human);

    }
    void Update()
    {
        rangeOrigin = transform.position;
    }

    public void DoHumanAttack(Human hm)
    {
        human = hm;
        if (human)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(rangeOrigin, rangeRadius, offenderLayer);

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
        if(human!= null)
        {
            yield return new WaitForSeconds(0.1f);
            enemy.GetComponent<Enemy>().TakeDamage(1, human, enemy);
            //knockBack.DoKnockBack(human, enemy);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(rangeOrigin, rangeRadius);
    }
}
