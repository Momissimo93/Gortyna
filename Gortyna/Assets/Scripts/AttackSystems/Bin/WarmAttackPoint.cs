using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmAttackPoint: Attack
{
    public float rangeRadius;
    Vector2 rangeOrigin;
    public Worm worm;
    //private int heroLayer = 1 << 7;
    //private Transform target;
    //private Human human;
    //public Worm worm;
    private HeartsHealthVisual heartsHealthVisual;

    private void Start()
    {
        rangeOrigin = transform.position;
        offenderLayer = 1 << 7;
        SetOffender(worm);

        heartsHealthVisual = FindObjectOfType<HeartsHealthVisual>();
    }

    private void Update()
    {
        rangeOrigin = transform.position;
    }

    public void CheckHero()
    {
        Vector2 rangeOrigin = transform.position;
        RaycastHit2D range = Physics2D.CircleCast(rangeOrigin, rangeRadius, Vector2.zero, 1, offenderLayer);

        if (range)
        {
            if (range.collider.gameObject.CompareTag("Hero"))
            {
                SetReceiver(range.collider.gameObject.GetComponent<Human>());
                receiver.TakeDamage(1, offender, receiver);
                heartsHealthVisual.HeartHealthSystemOnDamaged(1);
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(rangeOrigin, rangeRadius);
    }
}
