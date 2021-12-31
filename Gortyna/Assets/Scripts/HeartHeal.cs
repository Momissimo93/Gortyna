using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHeal : MonoBehaviour
{
    [SerializeField] private int healAmount;
    HeartsHealthVisual heartsHealthVisual;

    private void Start()
    {
        heartsHealthVisual = FindObjectOfType<HeartsHealthVisual>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            if (heartsHealthVisual.CheckLifePoint() < heartsHealthVisual.CheckInitialLifePoint())
            {
                heartsHealthVisual.HeartHealthSystemOnHealed(healAmount);
                Destroy(this.gameObject);
            }
        }
    }
}
