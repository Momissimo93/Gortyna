using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmAttack : Attack
{
    [SerializeField] private Worm worm;
    [SerializeField] private HeartsHealthVisual heartsHealthVisual;
    [SerializeField] private float rangeRadius;
    Vector2 rangeOrigin;

    private void Start()
    {
        rangeOrigin = transform.position;
        offenderLayer = 1 << 7;
        //SetOffender(worm);
        heartsHealthVisual = FindObjectOfType<HeartsHealthVisual>();
        offender = worm;
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
            //Debug.Log("The enemy is in range");
            if (range.collider.gameObject.CompareTag("Hero"))
            {
                if (heartsHealthVisual && (range.collider.gameObject.GetComponent<Human>().immune == false) && !worm.immune && !worm.isDeath)
                {
                    //heartsHealthVisual.HeartHealthSystemOnDamaged(1);
                    SetReceiver(range.collider.gameObject.GetComponent<Human>());
                    receiver.TakeDamage(1, offender, receiver);
                    StartCoroutine(NotMoreDamages(1));
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(rangeOrigin, rangeRadius);
    }
    IEnumerator NotMoreDamages( float seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            //it runs 3 times and at each iteration it stops for a second --> so in total the characters will blink for 3 seconds
            yield return new WaitForSeconds(seconds);
        }
    }
}

