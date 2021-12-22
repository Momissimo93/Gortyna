using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmAttackPoint : MonoBehaviour
{
    private int heroLayer = 1 << 7;
    public float rangeRadius;
    Vector2 rangeOrigin;
    private Transform target;
    private Human human;
    public Worm worm;

    private void Start()
    {
        rangeOrigin = transform.position;
    }
    private void Update()
    {
        rangeOrigin = transform.position;
    }

    public void CheckHero()
    {
        Vector2 rangeOrigin = transform.position;
        RaycastHit2D range = Physics2D.CircleCast(rangeOrigin, rangeRadius, Vector2.zero, 1, heroLayer);

        if (range)
        {
            if (range.collider.gameObject.CompareTag("Hero"))
            {
                human = range.collider.gameObject.GetComponent<Human>();
                human.TakeDamage(1,worm,human);
                Debug.Log("Found it let's attack him");
                //target = range.collider.transform;
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(rangeOrigin, rangeRadius);
    }
}
