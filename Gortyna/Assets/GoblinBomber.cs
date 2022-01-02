using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBomber : MonoBehaviour
{
    private AIPlayerDetector_OverlapBox playerDetector_OverlapBox;
    private ThrowingBombs throwingBombs;
    public Bomb b;
    private bool isFirying = false;
    // Start is called before the first frame update
    void Start()
    {
        playerDetector_OverlapBox = gameObject.GetComponent<AIPlayerDetector_OverlapBox>();
        throwingBombs = gameObject.GetComponent<ThrowingBombs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetector_OverlapBox.playerDetected)
        {
            if(isFirying ==  false)
            {
                StartCoroutine("ThrowingBombs");
            }
        }
    }

    IEnumerator ThrowingBombs()
    {
        isFirying = true;
        b.SetTarget(playerDetector_OverlapBox.GetTarget());
        throwingBombs.Fire(b);
        yield return new WaitForSeconds(1.0f);
        isFirying = false;
        Debug.Log("End Coroutine");
    }
}
