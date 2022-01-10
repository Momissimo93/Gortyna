using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAttack : Attack
{
    [SerializeField] private float rangeRadius;
    private Vector2 rangeOrigin;
    private Human human;

    void Start()
    {
        rangeOrigin = transform.position;
        offenderLayer = 1 << 8;
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
            yield return new WaitForSeconds(0.15f);
            enemy.GetComponent<Enemy>().TakeDamage(1, human, enemy);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(rangeOrigin, rangeRadius);
    }
}
