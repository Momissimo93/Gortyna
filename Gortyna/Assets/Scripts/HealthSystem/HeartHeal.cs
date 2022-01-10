using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHeal : MonoBehaviour
{
    [SerializeField] private int healAmount;
    private HeartsHealthVisual heartsHealthVisual;
    Animator animator;

    private void Start()
    {
        heartsHealthVisual = FindObjectOfType<HeartsHealthVisual>();
        if(gameObject.GetComponent<Animator>())
        {
            animator = gameObject.GetComponent<Animator>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero") || collision.gameObject.CompareTag("Bird"))
        {
            if (heartsHealthVisual.CheckLifePoint() < heartsHealthVisual.CheckInitialLifePoint())
            {
                heartsHealthVisual.HeartHealthSystemOnHealed(healAmount);
                StartCoroutine(DestroyHeart());
            }
        }
    }

    IEnumerator DestroyHeart()
    {
        animator.SetTrigger("Heart_Desctruction");
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
