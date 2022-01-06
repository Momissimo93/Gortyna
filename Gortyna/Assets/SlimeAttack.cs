using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : Attack
{
    [SerializeField] Transform rangeOrigin;
    [SerializeField] float rangeRadius = 0.0f;
    [SerializeField] LayerMask detectorLayer;

    public Slime slime;
    HeartsHealthVisual heartsHealthVisual;
    // Start is called before the first frame update
    void Start()
    {
        //SetOffender(worm);
        heartsHealthVisual = FindObjectOfType<HeartsHealthVisual>();
        offender = slime;
    }

    // Update is called once per frame
    void Update()
    {
        //rangeOrigin = transform.position;
    }
    public void CheckHero()
    {
        RaycastHit2D range = Physics2D.CircleCast(rangeOrigin.transform.position, rangeRadius, Vector2.zero, 1, detectorLayer);

        if (range)
        {
            //Debug.Log("The enemy is in range");
            if (range.collider.gameObject.CompareTag("Hero"))
            {
                if (heartsHealthVisual && (range.collider.gameObject.GetComponent<Human>().immune == false) && !slime.immune && !slime.isDeath)
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
        Gizmos.DrawWireSphere(rangeOrigin.transform.position, rangeRadius);
    }
    IEnumerator NotMoreDamages(float seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            //it runs 3 times and at each iteration it stops for a second --> so in total the characters will blink for 3 seconds
            yield return new WaitForSeconds(seconds);
        }
    }
}
